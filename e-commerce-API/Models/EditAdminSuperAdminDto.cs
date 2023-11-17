using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class EditAdminSuperAdminDto
    {
        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
        public string Name { get; set; }

        [Required]
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo debe contener solo letras.")]
        public string LastName { get; set; }

        [Required]
        [RegularExpression("^\\d{10}$", ErrorMessage = "El numero debe estar compuesto por 10 cifras.")]
        public string PhoneNumber { get; set; }
    }
}
