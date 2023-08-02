using System.Reflection.Metadata;
using System.Security.Claims;
using DatingApp.Core.Domain.Entities;
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
        private readonly IPhotosService _photosService;

        public UsersController(IUsersService usersService, IPhotosService photosService)
        {
            _usersService = usersService;
            _photosService = photosService;
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

        [HttpPut()]
        public async Task<ActionResult> UpdateUser(AppUserUpdateDTO userUpdateDTO)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (username == null) return Unauthorized();
            
            var result = await _usersService.UpdateUserAsync(username, userUpdateDTO);
            if (!result) return BadRequest("Failed to update user");

            return NoContent();
        }

        [HttpPost("add-photo")]
        public async Task<ActionResult<PhotoDTO>> AddPhoto(IFormFile file)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (username == null) return Unauthorized();

            var user = await _usersService.GetUserAsyncNoDTO(username);
            if (user == null) return NotFound("User not found");

            var result = await _photosService.UploadPhoto(file);
            if(result.Error != null) return BadRequest(result.Error.Message);
            var photo = new Photo {
                Url = result.SecureUrl.AbsoluteUri,
                PublicId = result.PublicId
            };
            user.Photos.Add(photo);
            if(user.Photos.Count == 1) photo.IsMain = true;


            var saveResult = await _usersService.SaveChangesAsync();
            if(!saveResult) return BadRequest("Failed to add photo");

            return CreatedAtAction(nameof(GetUser), new {username = user.UserName}, photo.ToPhotoDTO());
        }

        [HttpPut("set-main-photo/{photoId}")]
        public async Task<ActionResult> SetMainPhoto(int photoId)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (username == null) return Unauthorized();

            var user = await _usersService.GetUserAsyncNoDTO(username);
            if (user == null) return NotFound("User not found");

            var photo = user.Photos.FirstOrDefault(p => p.Id == photoId);
            if (photo == null) return NotFound("Photo not found");
            if (photo.IsMain) return BadRequest("This is already your main photo");
            
            var currentMain = user.Photos.FirstOrDefault(p => p.IsMain);
            if (currentMain != null) currentMain.IsMain = false;
            photo.IsMain = true;

            var saveResult = await _usersService.SaveChangesAsync();
            if(!saveResult) return BadRequest("Failed to set main photo");

            return NoContent();
        }

        [HttpDelete("delete-photo/{photoId}")]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (username == null) return Unauthorized();

            var user = await _usersService.GetUserAsyncNoDTO(username);
            if (user == null) return NotFound("User not found");

            var photo = user.Photos.FirstOrDefault(p => p.Id == photoId);
            if (photo == null) return NotFound("Photo not found");
            if (photo.IsMain) return BadRequest("You cannot delete your main photo");
            if (photo.PublicId != null)
            {
                var result = await _photosService.DeletePhotoAsync(photo.PublicId);
                if (result.Error != null) return BadRequest(result.Error.Message);
            }
            user.Photos.Remove(photo);

            var saveResult = await _usersService.SaveChangesAsync();
            if(!saveResult) return BadRequest("Failed to delete photo");

            return NoContent();
        }
    }
}

