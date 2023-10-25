using e_commerce_API.Data.Entities;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using e_commerce_API.Models;
using AutoMapper;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(UserForCreation userForCreation) 
        {
            var userEntity = _mapper.Map<User>(userForCreation);
            _userService.CreateUser(userEntity);

            await _userService.SaveChangesAsync();
            return Ok(userEntity);
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
