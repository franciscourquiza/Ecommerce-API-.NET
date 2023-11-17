using e_commerce_API.Data.Entities;
using e_commerce_API.Models;

namespace e_commerce_API.Services.Interfaces
{
    public interface ISuperAdminService
    {
        List<SuperAdmin> GetSuperAdmins();
        void AddSuperAdmin(SuperAdminDto superAdminForCreation);
        
        void EditSuperAdmin(EditAdminSuperAdminDto superAdminEdited, string emailSuperAdmin);
        Task<bool> SaveChangesAsync();
    }
}
