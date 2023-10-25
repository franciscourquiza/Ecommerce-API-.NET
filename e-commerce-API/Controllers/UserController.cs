using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService) 
        { 
            _userService = userService;
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteUser(int userId) 
        {
            var userDelete = _userService.GetById(userId);
            if (userDelete != null) 
            {
                return BadRequest("Id inexistente");
            }

            _userService.DeleteUser(userDelete);
            await _userService.SaveChangesAsync();

            return NoContent();
        }
    }
}
