using e_commerce_API.Data.Entities;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using e_commerce_API.Models;

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
        public async Task<IActionResult> CreateUser(UserDto userForCreation) 
        {
            UserDto? userEntity = _mapper.Map<UserDto>(userForCreation);
            if (userEntity == null) 
            {
                return BadRequest();
            }
            _userService.AddUser(userEntity);

            await _userService.SaveChangesAsync();

            return CreatedAtRoute(nameof(CreateUser), userEntity);
        }
        [HttpDelete("{userEmail}")]
        public async Task<IActionResult> DeleteUser(string userEmail) 
        {
            var userEntityToDelete = _userService.GetByEmail(userEmail);
            if (userEntityToDelete == null) 
            {
                return BadRequest("Email inexistente");
            }

            _userService.DeleteUser(userEntityToDelete);
            await _userService.SaveChangesAsync();

            return NoContent();
        }
    }
}
