using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class ProductOrderDto
    {
        [Key]
        public int IdProduct { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "La cantidad de productos debe ser mayor que cero.")]
        public int ProductQuntity { get; set; }
    }
}
