using e_commerce_API.Data.Enum;
using e_commerce_API.Data.Enum.Product;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_API.Data.Entities
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public float Price { get; set; } = 0;

        public int Stock { get; set; } = 0;

        [Required]
        public string Brand { get; set; }

        [Required]
        public SizeClothes SizeClothes { get; set; }

        public StyleClothes StyleClothes { get; set; }

        [Required]
        public TypeClothes TypeClothes { get; set; }

        public bool IsDeleted { get; set; }

    }
}
