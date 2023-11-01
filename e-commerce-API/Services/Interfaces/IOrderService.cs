using e_commerce_API.Models;
using e_commerce_API.Data.Entities;

namespace e_commerce_API.Services.Interfaces
{
    public interface IOrderService
    {
        void AddOrder(Order newOrder);
        List<Order> GetOrders();
        List<Order> GetPendingOrders();
        Task<bool> SaveChangesAsync();
    }
}
