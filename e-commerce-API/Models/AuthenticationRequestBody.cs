using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class AuthenticationRequestBody
    {
        [EmailAddress(ErrorMessage = "Por favor, ingrese una dirección de correo electrónico válida.")]
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
