namespace Application.JOB.Interfaces;

public interface IGenericRepository<T> where T : class
{
    IQueryable<T> Entities { get; }
    Task<T?> GetByIdAsync(Guid id);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);

}
