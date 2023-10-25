using e_commerce_API.Models;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;

namespace e_commerce_API.Services.Interfaces
{
    public interface IUserService
    {
        public User? ValidateUser(AuthenticationRequestBody authenticationRequestBody);
        public User? GetById(int userId);
        Task<bool> SaveChangesAsync();
        void CreateUser(User userToCreate);
        void DeleteUser(User userToDelete);
    }
}
