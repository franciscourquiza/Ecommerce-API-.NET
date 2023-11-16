using AutoMapper;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_API.Services.Implementations
{
    public class AdminService: IAdminService
    {
        private EcommerceContext _context;
        private readonly IMapper _mapper;

        public AdminService(EcommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Admin> GetAdmins()
        {
            return _context.Admins.ToList();
        }
        public void AddAdmin(AdminDto newAdmin)
        {
            if (newAdmin == null)
            {
                throw new ArgumentNullException(nameof(newAdmin));
            }
            Admin? userEntity = _mapper.Map<Admin>(newAdmin);
            _context.Add(newAdmin);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
