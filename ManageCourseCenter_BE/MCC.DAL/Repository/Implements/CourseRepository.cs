using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class CourseRepository : RepositoryGeneric<Course>, ICourseRepository
{
    public CourseRepository(ManageCourseCenterContext context) : base(context)
    {
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

    public async Task<IEnumerable<Course>> GetCourseByNameAsync(string name)
    {
        return await _dbSet.Where(c => c.Name.Contains(name)).ToListAsync();
    }
}
