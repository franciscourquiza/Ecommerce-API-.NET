using AutoMapper;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;
using e_commerce_API.Data.Enum;
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
        public void AddOrder(Order newOrder) 
        { 
            if (newOrder == null) 
            {
                throw new ArgumentNullException(nameof(newOrder));
            }
            _context.Add(newOrder);
        }
        public List<Order> GetOrders() 
        {
            return _context.Orders.ToList();
        }
        public List<Order> GetPendingOrders() 
        {
            return _context.Orders.Where(o => o.State == OrderState.pending).ToList();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); //devuelve true si 1 o mas entidades fueron modificadas
        }
    }
}
