using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class UserDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Por favor, ingrese una dirección de correo electrónico válida.")]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
        public string LastName { get; set; }

        [RegularExpression("^\\d{10}$", ErrorMessage = "El numero debe estar compuesto por 10 cifras.")]
        public string PhoneNumber { get; set; }

        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d).{8,}$\r\n", ErrorMessage = "La contraseña debe contener al menos una letra minúscula,una mayuscula, un numero y al menos 8 caracteres")]
        public string Password { get; set; }


    }
}
