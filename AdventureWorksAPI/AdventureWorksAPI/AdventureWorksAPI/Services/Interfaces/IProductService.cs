using AdventureWorksAPI.Models.ViewModels;

namespace AdventureWorksAPI.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductItem> GetProductByNameAsync(string productName);

        Task AddProductAsync(ProductItem productItem);

        Task UpdateProductAsync(ProductItem productItem);

        Task DeleteProductAsync(int productId);

        Task<IEnumerable<ProductListItem>> GetAllProductsAsync();
    }
}
