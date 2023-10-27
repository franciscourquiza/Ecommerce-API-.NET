using e_commerce_API.Models;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;

namespace e_commerce_API.Services.Interfaces
{
    public interface IUserService
    {
        public User? GetByEmail(string userEmail);
        Task<bool> SaveChangesAsync();
        void DeleteUser(User userToDeleteDto);
        Tuple<bool, User?> ValidateUser(string? email, string? password);
        void AddUser(UserDto userForCreation);
    }
}
