using AutoMapper;
using e_commerce_API.Context;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace e_commerce_API.Services.Implementations
{
    public class ProductService: IProductService
    {
        private readonly EcommerceContext _context;
        private readonly IMapper _mapper;
        public ProductService(EcommerceContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.Where(p => !p.IsDeleted).ToList();
        }
        public void AddProduct(ProductDto productForCreation)
        {
            Product? newProduct = _mapper.Map<Product>(productForCreation);
            if (newProduct == null)
            {
                throw new ArgumentNullException(nameof(newProduct));
            }
            _context.Add(newProduct);
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id && !p.IsDeleted);
        }

        public void UpdateProduct(ProductDto productUpdated, Product productToUpdate)
        {

            _mapper.Map(productUpdated, productToUpdate);
            _context.Products.Update(productToUpdate);
        }
        
        public void DeleteProduct(Product productToDelete) 
        {
                productToDelete.IsDeleted = true;
                _context.Products.Update(productToDelete); 
        }

        public void UpdatePriceStock(ProductPriceStockDto productUpdated, Product productToUpdate)
        {
            
            _mapper.Map(productUpdated, productToUpdate);
            _context.Products.Update(productToUpdate);
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }
    }
}
