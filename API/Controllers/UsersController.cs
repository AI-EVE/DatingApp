using DatingApp.Core.DTOs;
using DatingApp.Core.ServiceContracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Authorize]
    public class UsersController : BaseApiController
    {
        
        private readonly IUsersService _usersService;

        public UsersController(IUsersService usersService)
        {
            _usersService = usersService;
        }
        

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUserDTO>>> GetUsers()
        {
            var users = await _usersService.GetUsersAsync();

            return Ok(users);
        }

        [HttpGet("{username}")]
        public async Task<ActionResult<AppUserDTO>> GetUser(string username)
        {
            var user = await _usersService.GetUserByUsernameAsync(username);

            return Ok(user);
        }
    }
}

