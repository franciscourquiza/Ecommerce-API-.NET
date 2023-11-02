using e_commerce_API.Models;
using e_commerce_API.Data.Entities;

namespace e_commerce_API.Services.Interfaces
{
    public interface IOrderService
    {
        Order AddOrder(OrderDto newOrder, string emailClient);

        Order GetOrderById(int id);
        List<Order> GetOrders();
        List<Order> GetPendingOrders();
        Task<bool> SaveChangesAsync();
    }
}
