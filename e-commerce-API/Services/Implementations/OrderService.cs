using AutoMapper;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;
using e_commerce_API.Data.Enum;
using e_commerce_API.Models;
using e_commerce_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

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

            List<int> orderedProductIds = newOrder.OrderedProducts.Select(op => op.IdProduct).ToList();
            List<int> orderedProductsQuantity = newOrder.OrderedProducts.Select(op => op.ProductQuntity).ToList();
            List <Product> productsOrder = _context.Products.Where(p => orderedProductIds.Contains(p.Id)).ToList();

            List<SaleOrderLine> salesOrderLine = new List<SaleOrderLine>(); 
            float totalPrice = 0;

            for (int i = 0; i < productsOrder.Count; i++)
            {
                var product = productsOrder[i];
                var quantity = orderedProductsQuantity[i];

                if (product.Stock >= quantity)
                {
                    product.Stock -= quantity;
                    totalPrice += quantity * product.Price;

                    SaleOrderLine saleOrderLine = new SaleOrderLine
                    {
                        ProductId = product.Id,
                        ProductQuntity = quantity
                    };
                    salesOrderLine.Add(saleOrderLine);
                }
                else
                {
                    throw new Exception();
                }
            }

            Client client = _context.Clients.FirstOrDefault(c => c.Email == emailClient);
            Order order = new Order
            {
                ClientEmail = emailClient, 
                OrderPrice = totalPrice,
                SaleOrderLines = salesOrderLine
            };
            foreach(var saleOrderLine  in salesOrderLine)
            {
                saleOrderLine.SaleOrderId = order.Id;
                _context.SaleOrderLines.Add(saleOrderLine);  
            }
            _context.Orders.Add(order);
            return order;

        }
        public Order GetOrderById(int id)
        {
            return _context.Orders
                .Include(a => a.SaleOrderLines)
                    .ThenInclude(p => p.Product)
                .SingleOrDefault(p => p.Id == id);
        }

        public List<Order?> GetShoppingHistory(string userEmail)
        {
            return _context.Orders
                 .Where(h => h.ClientEmail == userEmail)
                 .Include(a => a.SaleOrderLines)
                    .ThenInclude(p => p.Product)
                 .ToList();
        }
        public List<Order> GetOrders() 
        {
            return _context.Orders.
                Include((a => a.SaleOrderLines))
                    .ThenInclude(p => p.Product)
                .ToList();
        }
        public List<Order> GetPendingOrders() 
        {
            return _context.Orders
                .Where(o => o.State == OrderState.pending)
                .Include(a => a.SaleOrderLines)
                    .ThenInclude(p=>p.Product)
                .ToList();
        }
        public void EditOrderState(EditOrderStateDto state, int id) 
        { 
            Order orderStateToEdit = _context.Orders.SingleOrDefault(o => o.Id == id);
            Order orderStateEdited = _mapper.Map(state, orderStateToEdit);

            _context.Orders.Update(orderStateEdited);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); //devuelve true si 1 o mas entidades fueron modificadas
        }
    }
}
