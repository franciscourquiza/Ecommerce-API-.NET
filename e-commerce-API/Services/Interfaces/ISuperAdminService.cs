using e_commerce_API.Data.Entities;

namespace e_commerce_API.Services.Interfaces
{
    public interface ISuperAdminService
    {
        void AddSuperAdmin(SuperAdmin superAdminForCreation);
        Task<bool> SaveChangesAsync();
    }
}
