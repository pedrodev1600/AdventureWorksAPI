using AdventureWorksAPI.Models.ViewModels;
using AdventureWorksAPI.Services;
using AdventureWorksAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AdventureWorksAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: api/products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductListItem>>> GetAllProducts()
        {
            try
            {
                var products = await _productService.GetAllProductsAsync();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/products/{id}
        [HttpGet("{productName}")]
        public async Task<ActionResult<ProductItem>> GetProductByName(string productName)
        {
            try
            {
                var product = await _productService.GetProductByNameAsync(productName);
                if (product == null)
                {
                    return NotFound();
                }
                return Ok(product); 
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] ProductItem productItem)
        {
            if (productItem == null)
                return BadRequest("Product cannot be null.");

            try
            {
                await _productService.AddProductAsync(productItem);
                return CreatedAtAction(nameof(GetProductByName), new { id = productItem.Name }, productItem);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest($"Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] ProductItem productItem)
        {
            if (productItem == null || productItem.ProductId != id)
                return BadRequest("Product ID mismatch.");

            try
            {
                await _productService.UpdateProductAsync(productItem);
                return NoContent();  
            }
            catch (KeyNotFoundException)
            {
                return NotFound();  
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");  
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                await _productService.DeleteProductAsync(id);
                return NoContent();  
            }
            catch (KeyNotFoundException)
            {
                return NotFound();  
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}"); 
            }
        }
    }
}
