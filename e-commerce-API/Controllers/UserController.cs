using e_commerce_API.Data.Entities;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Diagnostics;
using e_commerce_API.Models;
using e_commerce_API.Services.Implementations;
using Microsoft.AspNetCore.Authorization;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpDelete("{userEmail}")]
        public async Task<IActionResult> DeleteUser(string userEmail)
        {
            string role =User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "SuperAdmin" ){
                var userEntityToDelete = _userService.GetByEmail(userEmail);
                if (userEntityToDelete == null)
                {
                    return NotFound("Email inexistente");
                }

                _userService.DeleteUser(userEntityToDelete);
                await _userService.SaveChangesAsync();
                return NoContent();
            }
            return Forbid();
        }
    }
}
