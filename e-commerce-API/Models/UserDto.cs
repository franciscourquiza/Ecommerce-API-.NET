using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class UserDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
