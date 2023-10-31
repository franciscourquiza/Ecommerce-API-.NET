using e_commerce_API.Data.Entities;

namespace e_commerce_API.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product GetProductById(int id);
        void AddProduct(Product productService);
        void DeleteProduct(Product productToDelete);
        Task<bool> SaveChangesAsync();
    }
}
