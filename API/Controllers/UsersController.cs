using DatingApp.Core.Domain.Entities;
using DatingApp.Infrastructure.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{

    [Authorize]
    public class UsersController : BaseApiController
    {
        
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.AsNoTracking().Include(u => u.Photos).ToListAsync();

            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<AppUser>> GetUser(string username)
        {
            var user = await _context.Users.AsNoTracking().Include(u => u.Photos).SingleOrDefaultAsync(u => u.UserName == username);

            return user;
        }
    }
}

