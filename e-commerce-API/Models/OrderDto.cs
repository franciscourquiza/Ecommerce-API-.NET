using e_commerce_API.Data.Entities;
using e_commerce_API.Data.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class OrderDto
    { 

        public int Id { get; set; }

        public Client Client { get; set; }

        public string ClientEmail { get; set; }

        public OrderState State { get; set; } = OrderState.pending;

        public DateTime OrderDate { get; private set; } = DateTime.Now.ToUniversalTime();

        public float OrderPrice { get; set; }

        public List<Product> OrderedProducts { get; set; } = new List<Product>();


    }
}
