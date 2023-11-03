using AutoMapper;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;
using e_commerce_API.Data.Enum;
using e_commerce_API.Models;
using e_commerce_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_API.Services.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IMapper _mapper;
        private readonly EcommerceContext _context;
        private readonly IClientService _clientService;
        public OrderService(IMapper mapper, IClientService clientService, EcommerceContext context)
        {
            _mapper = mapper;
            _clientService = clientService;
            _context = context;
        }
        public Order AddOrder(OrderDto newOrder, string emailClient) 
        { 
            if (newOrder == null) 
            {
                throw new ArgumentNullException(nameof(newOrder));
            }
            List<Product> productsOrder = _context.Products.Where(p => newOrder.OrderedProducts.Contains(p.Id)).ToList();
            foreach (var product in productsOrder)
            {
                product.Stock -= 1;
            }
            float totalPrice = productsOrder.Sum(p => p.Price);
            Client client = _context.Clients.FirstOrDefault(c => c.Email == emailClient);
            Order order = new Order
            {
                ClientEmail = emailClient, 
                OrderPrice = totalPrice,
                OrderedProducts = productsOrder
            };
            _context.Orders.Add(order);
            return order;

        }
        public Order GetOrderById(int id)
        {
            return _context.Orders
                .Include( a=> a.OrderedProducts)
                .SingleOrDefault(p => p.Id == id);
        }

        public List<Order?> GetShoppingHistory(string userEmail)
        {
            return _context.Orders.Where(h => h.ClientEmail == userEmail).Include(a => a.OrderedProducts).ToList();
        }
        public List<Order> GetOrders() 
        {
            return _context.Orders.Include((p=>p.OrderedProducts)).ToList();
        }
        public List<Order> GetPendingOrders() 
        {
            return _context.Orders.Where(o => o.State == OrderState.pending).Include((p => p.OrderedProducts)).ToList();
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); //devuelve true si 1 o mas entidades fueron modificadas
        }
    }
}
