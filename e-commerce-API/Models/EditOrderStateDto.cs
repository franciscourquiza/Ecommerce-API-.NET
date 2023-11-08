using e_commerce_API.Data.Entities;
using e_commerce_API.Data.Enum;
using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class EditOrderStateDto
    {
        [Required]
        public OrderState State { get; set; }
    }
}
