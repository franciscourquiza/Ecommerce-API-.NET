using e_commerce_API.Data.Entities;

namespace e_commerce_API.Services.Interfaces
{
    public interface IAdminService
    {
        void AddAdmin(Admin adminForCreation);
        Task<bool> SaveChangesAsync();
    }
}
