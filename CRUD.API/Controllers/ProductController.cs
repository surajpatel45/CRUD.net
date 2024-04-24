using CRUD.Domain;
using CRUD.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CRUD.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService productService;
        public ProductController(ProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<List<Product>> GetProductsAsync()
        {
            return await productService.ViewProductsAsync();
        }

        [HttpPost]
        public async Task<string> AddProductAsync(Product product)
        {
            return await productService.AddProductAsync(product);
        }

        [HttpPut]
        public async Task<IActionResult> ModifyProductAsync(int id, Product product)
        {
            var result = await productService.ModifyProductAsync(id, product);
            if (result.Equals("Product Detail Modified!"))
            {
                return CreatedAtAction(null,null, product);
            }
            return BadRequest(result);
        }

        [HttpDelete]
        public async Task<string> RemoveProductAsync(int id)
        {
            return await productService.RemoveProductAsync(id);
        }

        [HttpGet]
        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await productService.GetProductByIdAsync(id);
        }
    }
}
