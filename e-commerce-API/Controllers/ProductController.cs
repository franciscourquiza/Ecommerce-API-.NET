using AutoMapper;
using e_commerce_API.Data.Entities;
using e_commerce_API.Models;
using e_commerce_API.Services.Implementations;
using e_commerce_API.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_commerce_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
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
        [Authorize]
        public async Task<IActionResult> CreateProduct(ProductDto productForCreation)
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Admin")
            {
                
                if (productForCreation == null)
                {
                    return BadRequest();
                }
                _productService.AddProduct(productForCreation);

                await _productService.SaveChangesAsync();

                return CreatedAtRoute(nameof(GetProductById), productForCreation);
            }
            return Forbid();
        }

        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> UpdateProduct(int id, ProductDto product)
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Admin")
            {
                Product productToUpdate = _productService.GetProductById(id);
                if (productToUpdate == null)
                    return NotFound("Producto no encontrado");
                if (product == null)
                    return BadRequest();

                _mapper.Map(product, productToUpdate);

                _productService.UpdateProduct(productToUpdate);

                await _productService.SaveChangesAsync();

                return Ok(productToUpdate);
            }
            return Forbid();
        }

        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Admin")
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
            return Forbid();
        }

        [HttpPatch]
        [Authorize]
        public async Task<IActionResult> UpdatePriceStock(int id, ProductPriceStockDto product)
        {
            string role = User.Claims.SingleOrDefault(o => o.Type.Contains("role")).Value;
            if (role == "Admin")
            {
                Product productUpdateDto = _productService.GetProductById(id);

                if (productUpdateDto == null)
                    return NotFound("Producto no encontrado");
                if (product == null)
                    return BadRequest();

                _mapper.Map(product, productUpdateDto);

                _productService.UpdatePriceStock(productUpdateDto);

                await _productService.SaveChangesAsync();

                return Ok("Cambiado con Exito");
            }
            return Forbid();
        }
    }
}
