namespace AdventureWorksAPI.Data.Repositories.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task AddListAsync(IEnumerable<T> entityList);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task DeleteListAsync(IEnumerable<T> entityList);
    }
}
