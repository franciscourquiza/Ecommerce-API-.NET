using AutoMapper;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;
using e_commerce_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_API.Services.Implementations
{
    public class AdminService: IAdminService
    {
        private EcommerceContext _context;

        public AdminService(EcommerceContext context)
        {
            _context = context;

        }
        public void AddAdmin(Admin newAdmin)
        {
            if (newAdmin == null)
            {
                throw new ArgumentNullException(nameof(newAdmin));
            }
            _context.Add(newAdmin);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
