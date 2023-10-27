using e_commerce_API.Models;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;

namespace e_commerce_API.Services.Interfaces
{
    public interface IUserService
    {
        public UserDto? GetByEmail(string userEmail);
        Task<bool> SaveChangesAsync();
        void DeleteUser(UserDto userEntityToDelete);
        Tuple<bool, User?> ValidateUser(string? email, string? password);
        void AddUser(UserDto userEntity);
    }
}
