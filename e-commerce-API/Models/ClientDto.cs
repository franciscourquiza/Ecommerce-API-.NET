using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_API.Models
{
    public class ClientDto: UserDto
    {
        public string Adress { get; set; }
        public int Dni { get; set; }
    }
}
