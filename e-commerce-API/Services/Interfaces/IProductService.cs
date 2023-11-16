using e_commerce_API.Data.Entities;
using e_commerce_API.Models;

namespace e_commerce_API.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        void AddProduct(ProductDto productService);
        void UpdateProduct(ProductDto productUpdated, Product productToUpdate);
        void DeleteProduct(Product productToDelete);
        void UpdatePriceStock(ProductPriceStockDto productUpdated, Product productToUpdate);
        Task<bool> SaveChangesAsync();
    }
}
