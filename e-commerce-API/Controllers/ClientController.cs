using AutoMapper;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _clientService;
        private readonly IMapper _mapper;
        public ClientController(IClientService clientService, IMapper mapper)
        {
            _clientService = clientService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> GetClientsAsync() 
        {
            return Ok(await _clientService.GetClientsAsync());
        }

        [HttpPost]
        public IActionResult<OrderDto>
    }
}
