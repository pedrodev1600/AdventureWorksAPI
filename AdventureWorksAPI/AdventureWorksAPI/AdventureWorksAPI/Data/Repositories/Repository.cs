using Microsoft.EntityFrameworkCore;
using AdventureWorksAPI.Data.Repositories.Interfaces;

namespace AdventureWorksAPI.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        public readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null) throw new Exception($"Entity with id {id} not found.");
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task AddListAsync(IEnumerable<T> entityList)
        {
            foreach (var T in entityList)
            {
                await _dbSet.AddAsync(T);
            }

            await _context.SaveChangesAsync();
        }

        public async Task DeleteListAsync(IEnumerable<T> entityList)
        {
            foreach (var T in entityList)
            {
                _dbSet.Remove(T);
            }

            await _context.SaveChangesAsync();
        }
    }
}
