using Microsoft.EntityFrameworkCore;

using TwoOne.Domain.Common.Repositories;

namespace TwoOne.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    private readonly AppDbContext _context;
    private readonly DbSet<T> _dbSet;

    public GenericRepository(AppDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }
    
    public async Task<List<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void AddAsync(T entity)
    {
         _dbSet.Add(entity);
    }

    public void UpdateAsync(T entity)
    {
         _dbSet.Update(entity);
    }

    public void DeleteAsync(T entity)
    {
        _dbSet.Remove(entity);
    }
}