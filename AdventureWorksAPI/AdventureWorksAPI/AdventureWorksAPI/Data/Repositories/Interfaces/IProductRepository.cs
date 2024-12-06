using AdventureWorksAPI.Models;


namespace AdventureWorksAPI.Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByNameAsync(string productName);

        Task DeleteProductAsync(int id);
    }
}
