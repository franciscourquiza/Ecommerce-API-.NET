using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_API.Models
{
    public class ClientDto: UserDto
    {
        [Required]
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "El campo no debe contener símbolos ni caracteres especiales.")]
        public string Adress { get; set; }

        [Required]
        [RegularExpression("^[0-9]{8}$", ErrorMessage = "El campo DNI debe contener 8 dígitos.")]
        public int Dni { get; set; }
    }
}
