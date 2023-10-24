﻿using e_commerce_API.Data.Enum;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace e_commerce_API.Data.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [ForeignKey("ClientId")]

        public Client Client { get; set; }

        public int ClientId { get; set; }

        public OrderState State { get; set; } = OrderState.pending;

        public DateTime OrderDate { get; private set; } = DateTime.Now.ToUniversalTime();

        public float OrderPrice { get; set; }

        public List<Product> OrderedProducts { get; set; } = new List<Product>();


    }
}
