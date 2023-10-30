using e_commerce_API.Context;
using e_commerce_API.Data.Entities;
using e_commerce_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_API.Services.Implementations
{
    public class SuperAdminService: ISuperAdminService
    {
        private EcommerceContext _context;
        public SuperAdminService(EcommerceContext context)
        {
            _context = context;
        }
        public void AddSuperAdmin(SuperAdmin newSuperAdmin)
        {
            if (newSuperAdmin == null)
            {
                throw new ArgumentNullException(nameof(newSuperAdmin));
            }
            _context.Add(newSuperAdmin);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); 
        }
    }
}
