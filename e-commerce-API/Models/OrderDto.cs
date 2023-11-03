﻿using e_commerce_API.Data.Entities;


namespace e_commerce_API.Models
{
    public class OrderDto
<<<<<<< HEAD
    {
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "El campo Id debe ser mayor que 0.")]
        public int Id { get; set; }

        [Required]
        public Client Client { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Por favor, ingrese una dirección de correo electrónico válida.")]
        public string ClientEmail { get; set; }

        public OrderState State { get; set; } = OrderState.pending;

        [DataType(DataType.DateTime, ErrorMessage = "El campo debe ser una fecha y hora válida.")]
        public DateTime OrderDate { get; private set; } = DateTime.Now.ToUniversalTime();

        [Range(0.01, double.MaxValue, ErrorMessage = "El campo Precio debe ser mayor que 0.")]
        public float OrderPrice { get; set; }

        public List<Product> OrderedProducts { get; set; } = new List<Product>();

=======
    { 
        public List<int> OrderedProducts { get; set; } 
>>>>>>> 38c1dbe1e712ad1a0cc4fe3b9035e981e389c4f0

    }
}
