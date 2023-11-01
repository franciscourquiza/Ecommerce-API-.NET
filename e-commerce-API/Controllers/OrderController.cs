using AutoMapper;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Implementations;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrder(OrderDto orderForCreation) 
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Client") 
            {
                Order? orderEntity = _mapper.Map<Order>(orderForCreation);
                if (orderEntity == null)
                {
                    return BadRequest();
                }
                _orderService.AddOrder(orderEntity);

                await _orderService.SaveChangesAsync();

                return CreatedAtRoute(nameof(CreateOrder), orderEntity);
            }
            return Forbid();
        }
        [HttpGet]
        public IActionResult GetOrders() 
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Admin")
                return Ok(_orderService.GetOrders());
            return Forbid();
        }
        [HttpGet]
        public IActionResult GetPendingOrders() 
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Admin")
                return Ok(_orderService.GetPendingOrders());
            return Forbid();
        }
    }
}
