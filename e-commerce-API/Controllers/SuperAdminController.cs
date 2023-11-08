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
    public class SuperAdminController : ControllerBase
    {
        private readonly ISuperAdminService _superAdminService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public SuperAdminController(ISuperAdminService superAdminService, IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _superAdminService = superAdminService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetSuperAdmins()
        {
            string role = User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "SuperAdmin")
                return Ok(_superAdminService.GetSuperAdmins());
            return Forbid();
        }

        [HttpGet("{email}", Name = nameof(GetSuperAdminByEmail))]
        public IActionResult GetSuperAdminByEmail(string email)
        {
            var superAdmin = _userService.GetByEmail(email);
            if (superAdmin == null)
            {
                return NotFound("Email no encontrado");
            }
            return Ok(superAdmin);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSuperAdmin(SuperAdminDto superAdminForCreation)
        {
            SuperAdmin? userEntity = _mapper.Map<SuperAdmin>(superAdminForCreation);
            string role = User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "SuperAdmin")
            {
                if (_userService.GetByEmail(userEntity.Email) != null)
                {
                    return Conflict("Este Email ya esta en uso");
                }
                if (userEntity == null)
                {
                    return BadRequest();
                }
                _superAdminService.AddSuperAdmin(userEntity);

                await _superAdminService.SaveChangesAsync();

                return CreatedAtRoute(nameof(GetSuperAdminByEmail), new { email = userEntity.Email }, userEntity);
            }
            return Forbid();

        }
    }
}
