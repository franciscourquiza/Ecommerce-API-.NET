using e_commerce_API.Data.Enum.Product;
using e_commerce_API.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class ProductDto
    {

        public float Price { get; set; } = 0;

        public int Stock { get; set; } = 0;
        
        public string Brand { get; set; }

        public SizeClothes SizeClothes { get; set; }

        public StyleClothes StyleClothes { get; set; }
        
        public TypeClothes TypeClothes { get; set; }
    }
}
