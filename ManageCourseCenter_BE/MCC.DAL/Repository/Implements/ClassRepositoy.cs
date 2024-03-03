using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class ClassRepositoy : RepositoryGeneric<Class>, IClassReposotory
{
    public ClassRepositoy(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<Class> GetClassByNameAsync(string name)
    {
        return await _dbSet.SingleOrDefaultAsync(c => c.Name == name);
    }

    public async Task<IEnumerable<Class>> GetCourseByNameAsync(string name)
    {
        return await _dbSet.Where(c => c.Name.Contains(name)).ToListAsync();
    }

    public async Task<bool> CheckExistingNameAsync(string name)
    {
        var existing = await _dbSet.SingleOrDefaultAsync(m => m.Name == name);
        if (existing == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
