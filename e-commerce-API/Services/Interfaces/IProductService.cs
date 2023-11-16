using e_commerce_API.Data.Entities;
using e_commerce_API.Models;

namespace e_commerce_API.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        void AddProduct(ProductDto productService);
        void UpdateProduct(ProductDto updatedProduct);
        void DeleteProduct(Product productToDelete);
        void UpdatePriceStock(ProductPriceStockDto updateProduct);
        Task<bool> SaveChangesAsync();
    }
}
