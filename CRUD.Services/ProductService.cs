using CRUD.Data;
using CRUD.Domain;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CRUD.Services
{
    public class ProductService
    {
        private readonly MyDbContext context;
        public ProductService(MyDbContext context)
        {
            this.context = context;
        }

        public async Task<List<Product>> ViewProductsAsync()
        {
            return await context.Products.ToListAsync();
        }
        public async Task<string> AddProductAsync(Product product)
        {
            try
            {
                await context.Products.AddAsync(product);
                await context.SaveChangesAsync();
                return "Product Added!";
            }
            catch (Exception ex)
            {
                return "Failed to add Product " + ex.Message;
            }
        }
        public async Task<string> ModifyProductAsync(int id, Product product)
        {
            var existingProduct = await context.Products.FindAsync(id);

            if (existingProduct == null)
            {
                return "Product not found";
            }
            if( id!= product.Id )
            {
                return "Id not matched";
            }
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.UnitPrice = product.UnitPrice; 
            existingProduct.Quantity = product.Quantity;
            await context.SaveChangesAsync();
            return "Product Detail Modified!";
        }
        public async Task<string> RemoveProductAsync(int id)
        {
            var product = await context.Products.FindAsync(id);
            if (product == null)
            {
                return "Product not found";
            }
            context.Products.Remove(product);
            await context.SaveChangesAsync();
            return "Product Rmoved!";
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await context.Products.FindAsync(id);
        }
    }
}
