using e_commerce_API.Data.Enum.Product;
using e_commerce_API.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class ProductDto
    {
        [Required]
        [Range(0.00, double.MaxValue, ErrorMessage = "El campo Precio debe ser mayor o igual que 0.")]
        public float Price { get; set; } = 0;

        [Range(0, int.MaxValue, ErrorMessage = "El campo Stock debe ser mayor o igual que 0.")]
        public int Stock { get; set; } = 0;

        
        [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "El campo no debe contener símbolos ni números.")]
        public string Brand { get; set; }


        public SizeClothes SizeClothes { get; set; }

        public StyleClothes StyleClothes { get; set; }

        [Required]
        public TypeClothes TypeClothes { get; set; }
    }
}
