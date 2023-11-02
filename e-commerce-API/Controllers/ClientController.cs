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
        [Authorize]

        public IActionResult GetClients() 
        {
            string role = User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "Admin" )
                return Ok(_clientService.GetClients());
            return Forbid();
        }
        [HttpGet("{email}", Name = nameof(GetClientByEmail))]
        public IActionResult GetClientByEmail(string email)
        {
            var client = _userService.GetByEmail(email);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
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

            return CreatedAtRoute(nameof(GetClientByEmail), new { email = userEntity.Email }, userEntity);

        }
        [HttpPut]
        [Authorize]

        public async Task<IActionResult> EditClient(EditClientDto clientEdited)
        {
            string emailClient = User.Claims.SingleOrDefault(c => c.Type.Contains("nameidentifier")).Value;
            _clientService.EditClient(clientEdited, emailClient);
            await _clientService.SaveChangesAsync();
            return Ok(clientEdited);
        }
    }
}
