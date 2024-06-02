using Application.Contracts.IRepositories;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
        }

        public async Task<List<T>> GetAllAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includePropeties = null)
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrWhiteSpace(includePropeties))
            {
                foreach (var includeProperty in includePropeties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            var entities = await query
                .Where(filter)
                .ToListAsync();

            return entities;
        }

        public async Task<List<T>> GetAllAsync(string? includePropeties = null)
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrWhiteSpace(includePropeties))
            {
                foreach (var includeProperty in includePropeties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            var entities = await query.ToListAsync();

            return entities;
        }

        public async Task<T?> GetAsync(System.Linq.Expressions.Expression<Func<T, bool>> filter, string? includePropeties = null)
        {
            IQueryable<T> query = _dbSet;

            if (!string.IsNullOrWhiteSpace(includePropeties))
            {
                foreach (var includeProperty in includePropeties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }

            var entities = await query.FirstOrDefaultAsync(filter);

            return entities;
        }

        public void Remove(T entity)
        {
            _dbSet.Remove(entity);
        }
    }
}
