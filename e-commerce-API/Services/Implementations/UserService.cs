using e_commerce_API.Services.Interfaces;
using AutoMapper;
using e_commerce_API.Context;
using e_commerce_API.Models;
using e_commerce_API.Data;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using e_commerce_API.Data.Entities;

namespace e_commerce_API.Services.Implementations
{
    public class UserService : IUserService
    {
        private EcommerceContext _context;
        private readonly IMapper _mapper;
        public UserService(EcommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public User? ValidateUser(AuthenticationRequestBody authenticationRequestBody)
        {
            return _context.Users.FirstOrDefault(p => p.Email == authenticationRequestBody.Email && p.Password == authenticationRequestBody.Password);
        }

        public User? GetById(int userId)
        {
            return _context.Users.SingleOrDefault(u => u.Id == userId);
        }
        public void DeleteUser(User userToDelete) 
        {
            if (userToDelete != null) 
            {
                throw new ArgumentNullException(nameof(userToDelete));
            }
            _context.Users.Remove(userToDelete);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return(await _context.SaveChangesAsync() > 0); //devuelve true si 1 o mas entidades fueron modificadas
        }
    }
}
