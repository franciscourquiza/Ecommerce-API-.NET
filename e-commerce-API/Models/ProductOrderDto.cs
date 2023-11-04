using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class ProductOrderDto
    {
        [Key]
        public int IdProduct { get; set; }

        public int ProductQuntity { get; set; }
    }
}
