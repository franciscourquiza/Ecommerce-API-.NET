using AutoMapper;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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

        [HttpPost]
        public async Task<IActionResult> CreateSuperAdmin(SuperAdminDto superAdminForCreation)
        {
            SuperAdmin? userEntity = _mapper.Map<SuperAdmin>(superAdminForCreation);
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

            return CreatedAtRoute(nameof(CreateSuperAdmin), new { email = userEntity.Email }, userEntity);

        }
    }
}
