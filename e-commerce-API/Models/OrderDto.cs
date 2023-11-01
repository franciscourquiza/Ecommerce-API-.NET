using e_commerce_API.Data.Entities;
using e_commerce_API.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class OrderDto
    { 
        public List<Product> OrderedProducts { get; set; } = new List<Product>();


    }
}
