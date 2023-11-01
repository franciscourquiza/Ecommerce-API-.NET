using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_API.Models
{
    public class ClientDto: UserDto
    {
        [RegularExpression(@"^\d+$", ErrorMessage = "El campo no debe tener simbolos")]
        public string Adress { get; set; }

        [RegularExpression("^[0-9]+$", ErrorMessage = "El campo debe contener solo numeros")]
        public int Dni { get; set; }
    }
}
