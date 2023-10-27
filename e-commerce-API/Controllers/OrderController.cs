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
        public Task<IActionResult> CreateOrder(OrderDto orderDto) 
        {
            var orderEntity = _mapper.Map<Order>(orderDto);
            _orderService.CreateOrder(orderDto);
        }
    }
}
