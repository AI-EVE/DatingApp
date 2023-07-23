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
        public async Task<ActionResult<AppUser>> Register(RegisterDTO registerDTO)
        {

            if(await UserExists(registerDTO.Username))
            {
                return BadRequest("Username is taken");
            }


            var user = new AppUser();
            user.UserName = registerDTO.Username?.ToLower();

            using var hmac = new HMACSHA512();

            user.PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(registerDTO.Password));
            user.PasswordSalt = hmac.Key;

            _context.Users?.Add(user);
            await _context.SaveChangesAsync();

            return user;
        } 

        [HttpPost("login")]
        public async Task<ActionResult<UserDTO>> Login(LoginDTO loginDTO)
        {
            var user = await _context.Users?.SingleOrDefaultAsync(x => x.UserName == loginDTO.Username.ToLower());

            if(user is null) return Unauthorized("Invalid username");

            using var hmac = new HMACSHA512(user.PasswordSalt);

            var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(loginDTO.Password));

            for(int i = 0; i < computedHash.Length; i++)
            {
                if(computedHash[i] != user.PasswordHash[i]) return Unauthorized("Invalid password");
            }

            return new UserDTO
            {
                Username = user.UserName,
                Token = _tokenGenerator.GenerateToken(user)
            };
        }


        private async Task<bool> UserExists(string? username)
        {
            return await _context.Users.AnyAsync(x => x.UserName == username.ToLower());
        }
    }
}