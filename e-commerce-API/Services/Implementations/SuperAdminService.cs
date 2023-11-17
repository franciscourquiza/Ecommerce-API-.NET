using AutoMapper;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace e_commerce_API.Services.Implementations
{
    public class SuperAdminService: ISuperAdminService
    {
        private EcommerceContext _context;
        private readonly IMapper _mapper;
        public SuperAdminService(EcommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<SuperAdmin> GetSuperAdmins()
        {
            return _context.SuperAdmins.ToList();
        }
        public void AddSuperAdmin(SuperAdminDto superAdminForCreation)
        {
            if (superAdminForCreation == null)
            {
                throw new ArgumentNullException(nameof(superAdminForCreation));
            }
            SuperAdmin? newSuperAdmin = _mapper.Map<SuperAdmin>(superAdminForCreation);
            _context.Add(newSuperAdmin);
        }

        public void EditSuperAdmin(EditAdminSuperAdminDto superAdmin, string emailSuperAdmin)
        {
            SuperAdmin adminToEdit = _context.SuperAdmins.SingleOrDefault(u => u.Email == emailSuperAdmin);
            SuperAdmin adminEdited = _mapper.Map(superAdmin, adminToEdit);

            _context.SuperAdmins.Update(adminEdited);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0); 
        }
    }
}
