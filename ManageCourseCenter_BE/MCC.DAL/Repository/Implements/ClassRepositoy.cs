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

    public async Task<IEnumerable<Class>> GetCourseByNameAsync(string name)
    {
        return await _dbSet.Where(c => c.Name.Contains(name)).ToListAsync();
    }
}
