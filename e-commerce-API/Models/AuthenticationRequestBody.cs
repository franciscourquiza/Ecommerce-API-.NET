using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class AuthenticationRequestBody
    {
        [Required]
        [EmailAddress(ErrorMessage = "Por favor, ingrese una dirección de correo electrónico válida.")]
        public string? Email { get; set; }

        [Required]
        public string? Password { get; set; }
    }
}
