using AutoMapper;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> CreateOrder(OrderDto order) 
        {
            try
            {
                string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
                if (role == "Client")
                {
                    if (order == null)
                    {
                        return BadRequest();
                    }
                    string emailClient = User.Claims.SingleOrDefault(c => c.Type.Contains("nameidentifier")).Value;
                    Order createdOrder = _orderService.AddOrder(order, emailClient);

                    await _orderService.SaveChangesAsync();
                    return CreatedAtRoute(nameof(GetOrderById), new { id = createdOrder.Id }, createdOrder);
                }
                return Forbid();
            }
            catch (Exception)
            {
                return BadRequest("Error: La cantidad pedida del producto es mayor que el stock disponible.");
            }
        }

        [HttpGet("{id}", Name = "GetOrderById")]
        public IActionResult GetOrderById(int id)
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Client" || role == "Admin")
            {
                var order = _orderService.GetOrderById(id);

                if (order == null)
                {
                    return NotFound("Pedido no encontrado");
                }
                return Ok(order);
            }
            return Forbid();
        }

        [HttpGet("GetShoppingHistory")]
        public IActionResult GetShoppingHistory()
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if(role == "Client")
            {
                string emailClient = User.Claims.SingleOrDefault(c => c.Type.Contains("nameidentifier")).Value;
                return Ok(_orderService.GetShoppingHistory(emailClient));
            }
            return Forbid();
        }

        [HttpGet("GetAllOrders")]
        public IActionResult GetOrders() 
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Admin")
                return Ok(_orderService.GetOrders());
            return Forbid();
        }

        [HttpGet("GetPendingOrders")]
        public IActionResult GetPendingOrders() 
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Admin")
                return Ok(_orderService.GetPendingOrders());
            return Forbid();
        }
    }
}
