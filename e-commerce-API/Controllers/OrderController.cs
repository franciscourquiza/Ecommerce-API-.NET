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
            OrderDto? orderEntity = _mapper.Map<OrderDto>(orderForCreation);
            if (orderEntity == null) 
            {
                return BadRequest();
            }
            _orderService.CreateOrder(orderEntity);

            await _orderService.SaveChangesAsync();
            return CreatedAtRoute(nameof(CreateOrder), orderEntity);
        }
    }
}
