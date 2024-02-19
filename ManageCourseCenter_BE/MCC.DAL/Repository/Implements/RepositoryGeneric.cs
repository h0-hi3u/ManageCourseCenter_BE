using MCC.DAL.EntityModels.Context;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class RepositoryGeneric<T> : IRepositoryGeneric<T> where T : class
{
    public ManageCourseCenterContext _context;
    public DbSet<T> _dbSet;
    public RepositoryGeneric(ManageCourseCenterContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }

    public async Task AddAsync(T entity)
    {
        await _dbSet.AddAsync(entity);
    }

    public void Delete(T entity)
    {
        _dbSet.Remove(entity);
    }

    public DbSet<T> Entities()
    {
        return _context.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }


    public void Update(T entity)
    {
        _dbSet.Update(entity);
    }
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }

}
