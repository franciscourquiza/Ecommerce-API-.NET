using e_commerce_API.Data.Entities;
using System.ComponentModel.DataAnnotations;


namespace e_commerce_API.Models
{
    public class OrderDto
    {
        [Required]
        public List<int> OrderedProducts { get; set; }

    }
}
