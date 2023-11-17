using e_commerce_API.Data.Entities;
using e_commerce_API.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class EditOrderStateDto
    {
        [Required]
        [EnumDataType(typeof(OrderState), ErrorMessage = "Valor de estado no válido")]
        public OrderState State { get; set; }
    }
}
