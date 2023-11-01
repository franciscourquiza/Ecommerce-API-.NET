using e_commerce_API.Services.Interfaces;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;

namespace e_commerce_API.Services.Implementations
{

    public class UserService : IUserService
    {
        
        private readonly EcommerceContext _context;
        public UserService(EcommerceContext context)
        {
            _context = context;
        }

        public Tuple<bool,User?> ValidateUser(string email, string password)
        {
            User? userForLogin = _context.Users.SingleOrDefault(u => u.Email == email);
            if (userForLogin != null) 
            { 
                if (userForLogin.Password == password)
                    return new Tuple<bool,User?>(true, userForLogin);
                return new Tuple<bool,User?>(false, userForLogin);
            }
            return new Tuple<bool, User?>(false, null);   
        }

        public User? GetByEmail(string userEmail)
        {
            return _context.Users.SingleOrDefault(u => u.Email == userEmail);
        }
        
        public void DeleteUser(User userToDeleteDto) 
        {
            if (userToDeleteDto == null) 
            {
                throw new ArgumentNullException(nameof(userToDeleteDto));
            }
            _context.Remove(userToDeleteDto);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return(await _context.SaveChangesAsync() > 0); 
        }
    }
}
