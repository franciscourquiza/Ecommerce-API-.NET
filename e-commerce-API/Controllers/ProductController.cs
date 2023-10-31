using AutoMapper;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Implementations;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly IMapper _mapper;
        public ProductController(IProductService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            return Ok(_productService.GetProducts());
        }

        [HttpGet("{id}", Name = nameof(GetProductById))]
        public IActionResult GetProductById(int id)
        {
            var product = _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(ProductDto productForCreation)
        {
            Product? product = _mapper.Map<Product>(productForCreation);
            if (product == null)
            {
                return BadRequest();
            }
            _productService.AddProduct(product);

            await _productService.SaveChangesAsync();

            return CreatedAtRoute(nameof(GetProductById), new { id = product.Id }, product);
        }
        [HttpPut("{id}")]

        public async Task<IActionResult> UpdateProduct(int id, ProductDto product)
        {
            Product productToUpdate = _productService.GetProductById(id);

            if ( productToUpdate== null)
                return NotFound("Producto no encontrado");
            if (product == null)
                return BadRequest();

            _mapper.Map(product, productToUpdate);

            _productService.UpdateProduct(productToUpdate);

            await _productService.SaveChangesAsync();

            return Ok(productToUpdate);
        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> DeleteProduct(int id)
        {
            Product productToDelete = _productService.GetProductById(id);

            if (productToDelete == null)
            {
                return NotFound("Producto no encontrado");
            }
            _productService.DeleteProduct(productToDelete);

            await _productService.SaveChangesAsync();
            
            return NoContent();
        }

    }
}
