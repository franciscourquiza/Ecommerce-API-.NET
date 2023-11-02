using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_API.Models
{
    public class ClientDto: UserDto
    {
        [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "El campo no debe contener símbolos ni caracteres especiales.")]
        public string Adress { get; set; }
        public int Dni { get; set; }
    }
}
