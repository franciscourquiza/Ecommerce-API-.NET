using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class AuthenticationRequestBody
    {
        [EmailAddress]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
