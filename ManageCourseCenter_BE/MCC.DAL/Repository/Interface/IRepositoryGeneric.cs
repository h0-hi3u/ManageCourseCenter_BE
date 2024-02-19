using Microsoft.EntityFrameworkCore;
namespace MCC.DAL.Repository.Interface;

public interface IRepositoryGeneric<T> where T : class
{
    DbSet<T> Entities();
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
    Task SaveChangesAsync();
}
