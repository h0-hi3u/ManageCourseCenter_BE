using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class ClassTimeRepository : RepositoryGeneric<ClassTime>, IClassTimeRepository
{
    public ClassTimeRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ClassTime>> GetClassTimeByClassIdAsync(int classId)
    {
        return await _dbSet.Where(c => c.ClassId == classId).ToListAsync();
    }

    public async Task<IEnumerable<ClassTime>> GetClassTimeByClassNameAsync(string className)
    {
        return await _dbSet.Where(c => c.Class.Name == className).ToListAsync();
    }
}
