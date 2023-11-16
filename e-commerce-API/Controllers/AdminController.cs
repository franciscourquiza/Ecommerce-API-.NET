using AutoMapper;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Implementations;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AdminController : ControllerBase
    {
        private readonly IAdminService _adminService;
        private readonly IUserService _userService;

        public AdminController(IAdminService adminService, IUserService userService)
        {
            _userService = userService;
            _adminService = adminService;
        }

        [HttpGet]
        public IActionResult GetAdmins()
        {
            string role =User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "SuperAdmin" )
                return Ok(_adminService.GetAdmins());
            return Forbid();
        }

        [HttpGet("{email}", Name = nameof(GetAdminByEmail))]
        public IActionResult GetAdminByEmail(string email)
        {
            string role = User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "SuperAdmin")
            {
                var admin = _userService.GetByEmail(email);
                if (admin == null)
                    return NotFound("Admin no encontrado");
                return Ok(admin);
            }
            return Forbid();
        }
        [HttpPost]
        public async Task<IActionResult> CreateAdmin(AdminDto adminForCreation)
        {
            string role = User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "SuperAdmin")
            {
                
                if (_userService.GetByEmail(adminForCreation.Email) != null)
                {
                    return Conflict("Este Email ya esta en uso");
                }
                if (adminForCreation == null)
                {
                    return BadRequest();
                }
                _adminService.AddAdmin(adminForCreation);

                await _adminService.SaveChangesAsync();

                return CreatedAtRoute(nameof(GetAdminByEmail), new { email = adminForCreation.Email }, adminForCreation);
            }
            return Forbid();
        }
    }
}
