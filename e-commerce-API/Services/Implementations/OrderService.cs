using AutoMapper;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Interfaces;

namespace e_commerce_API.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly EcommerceContext _context;
        private readonly IClientService _clientService;
        private readonly IOrderService _orderService;
        public OrderService(IMapper mapper, IClientService clientService, EcommerceContext context, IOrderService orderService)
        {
            _mapper = mapper;
            _clientService = clientService;
            _orderService = orderService;
            _context = context;
        }
        public void CreateOrder(OrderDto orderDto) 
        { 
            if (orderDto == null) throw new ArgumentNullException(nameof(orderDto));
            _context.Orders.Add(_mapper.Map<Order>(orderDto));
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); //devuelve true si 1 o mas entidades fueron modificadas
        }
    }
}
