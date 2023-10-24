using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class AuthenticationRequestBody
    {
        [Required]
        public string? Username { get; set; }
        [Required]
        public string? Password { get; set; }
    }
}
