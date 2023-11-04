using e_commerce_API.Data.Entities;


namespace e_commerce_API.Models
{
    public class OrderDto
    { 
        public List<ProductOrderDto> OrderedProducts { get; set; } 

    }
}
