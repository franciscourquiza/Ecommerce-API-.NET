using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Data.Entities
{
    public abstract class User

    {
        [Key]
        [Required]
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string UserType { get; set; }

    }
}
