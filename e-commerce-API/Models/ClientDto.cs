using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_API.Models
{
    public class ClientDto
    {
        [EmailAddress]
        public string Email { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public string Adress { get; set; }
        public int Dni { get; set; }
    }
}
