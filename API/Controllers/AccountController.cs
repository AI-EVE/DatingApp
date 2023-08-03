using System.Security.Cryptography;
using System.Text;
using DatingApp.Core.Domain.Entities;
using DatingApp.Core.DTOs;
using DatingApp.Core.ServiceContracts;
using DatingApp.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    public class AccountController : BaseApiController
    {
        private readonly DataContext _context;
        private readonly ITokenGenerator _tokenGenerator;

        public AccountController(DataContext context, ITokenGenerator tokenGenerator)
        {
            _context = context;
            _tokenGenerator = tokenGenerator;
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponseDTO>> Register(RegisterDTO registerDTO)
        {

            if(await UserExists(registerDTO.Username))
            {
                return BadRequest("Username is taken");
            }

            if(registerDTO is null) return BadRequest("Invalid register info");
            if(registerDTO.Username is null) return BadRequest("Invalid username");


            var user = registerDTO.ToAppUser();

            using var hmac = new HMACSHA512();

            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password));
            user.PasswordSalt = hmac.Key;

            _context.Users?.Add(user);
            await _context.SaveChangesAsync();

            return new LoginResponseDTO
            {
                Username = user.UserName,
                Token = _tokenGenerator.GenerateToken(user),
                KnownAs = user.KnownAs
            };
        } 

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponseDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users?.AsNoTracking().Include(u => u.Photos).SingleOrDefaultAsync(x => x.UserName == loginDTO.Username.ToLower());

            if(user is null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new LoginResponseDTO
            {
                Username = user.UserName,
                Token = _tokenGenerator.GenerateToken(user),
                PhotoUrl = user.Photos.FirstOrDefault(p => p.IsMain)?.Url,
                KnownAs = user.KnownAs
            };
        }


        private async Task<bool> UserExists(string? username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}