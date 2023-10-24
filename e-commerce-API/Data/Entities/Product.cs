
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

        public float Price { get; set; }

        public int Stock { get; set; }

        public string Brand { get; set; }

        public SizeClothes SizeClothes { get; set; }
        
        public StyleClothes



        public enum sizeClothing { get;set }


    }
}
