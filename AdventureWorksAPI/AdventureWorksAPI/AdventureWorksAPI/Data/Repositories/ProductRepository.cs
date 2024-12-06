using AdventureWorksAPI.Data.Repositories.Interfaces;
using AdventureWorksAPI.Models;
using AdventureWorksAPI.Models.ViewModels;
using Microsoft.EntityFrameworkCore;
namespace AdventureWorksAPI.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(ApplicationDbContext context) :
            base(context)
        {

        }

        public async Task<Product> GetByNameAsync(string productName)
        {
            var product =  await _context.Products
                .FirstOrDefaultAsync(p => p.Name == productName);

            if (product == null)
            {
                throw new InvalidOperationException($"Product with name '{productName}' not found.");
            }

            return product;
        }

        public async Task DeleteProductAsync(int productId)
        {
            try
            {
                await _context.Database.ExecuteSqlRawAsync("EXEC dbo.DeleteProduct @p0", productId);
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"An error occurred while trying to delete product {productId}. See inner exception for details.", ex);
            }
        }
    }
}
