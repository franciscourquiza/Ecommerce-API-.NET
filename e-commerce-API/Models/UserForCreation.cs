using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class UserForCreation
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
    }
}
