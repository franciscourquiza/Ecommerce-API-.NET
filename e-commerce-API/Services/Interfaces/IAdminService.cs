using e_commerce_API.Data.Entities;
using e_commerce_API.Models;

namespace e_commerce_API.Services.Interfaces
{
    public interface IAdminService
    {
        List<Admin> GetAdmins();
        void AddAdmin(AdminDto adminForCreation);

        void EditAdmin(EditAdminSuperAdminDto adminEdited, string emailClient);
        Task<bool> SaveChangesAsync();
    }
}
