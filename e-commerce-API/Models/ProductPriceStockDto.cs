using System.ComponentModel.DataAnnotations;

namespace e_commerce_API.Models
{
    public class ProductPriceStockDto
    {
        [Range(1, double.MaxValue, ErrorMessage = "El campo Precio debe ser mayor que 1.")]
        public int UpdatePrice { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "El campo Stock debe ser mayor o igual que 0.")]
        public int UpdateStock { get; set; }
    }
}
