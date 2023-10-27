using e_commerce_API.Models;

namespace e_commerce_API.Services.Interfaces
{
    public interface IOrderService
    {
        void CreateOrder(OrderDto orderDto);
        Task<bool> SaveChangesAsync();
    }
}
