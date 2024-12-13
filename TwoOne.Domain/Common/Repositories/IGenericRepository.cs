namespace TwoOne.Domain.Common.Repositories;

public interface IGenericRepository<T> where T : class
{
    Task<List<T>> GetAllAsync();
    Task<T?> GetByIdAsync(Guid id);
    void AddAsync(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(T entity);
}