using AutoMapper;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Implementations;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;
        public ClientController(IClientService clientService,IUserService userService ,IMapper mapper)
        {
            _userService = userService;
            _clientService = clientService;
            _mapper = mapper;
        }

        [HttpGet]
        
        public IActionResult GetClients() 
        {
            //string role =User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            //if (role == "Admin" )
                return Ok(_clientService.GetClients());
            //return Forbid();
        }
        [HttpPost]
        public async Task<IActionResult> CreateClient(ClientDto clientForCreation)
        {
            Client? userEntity = _mapper.Map<Client>(clientForCreation);
            if (_userService.GetByEmail(userEntity.Email) != null)
            {
                return Conflict("Este Email ya esta en uso");
            }
            if (userEntity == null)
            {
                return BadRequest();
            }
            _clientService.AddClient(userEntity);

            await _clientService.SaveChangesAsync();

            return CreatedAtRoute(nameof(CreateClient), userEntity);
        }
        //[HttpPost]
        //public IActionResult<OrderDto>
    }
}
