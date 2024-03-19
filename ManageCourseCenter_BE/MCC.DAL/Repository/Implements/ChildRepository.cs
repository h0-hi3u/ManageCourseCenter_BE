using MCC.DAL.Constants;
using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interfacep;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class ChildRepository : RepositoryGeneric<Child>, IChildRepository
{
    public ChildRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<Child> GetChildrenByUsernameAndPassword(string username, string password)
    {
        return await _dbSet.SingleOrDefaultAsync(c => c.Username == username && c.Password == password && c.Status == CoreConstants.STT_CHILDREN_ACTIVE);
    }

    public async Task<IEnumerable<Child>> GetChildrenListNotEnrollCourseAsync(int parentId, int courseId)
    {
        var parent = await _context.Parents
                .Include(p => p.Children)
                .FirstOrDefaultAsync(p => p.Id == parentId);

        var classesInCourse = await _context.Classes
            .Where(c => c.CourseId == courseId)
            .SelectMany(c => c.ChildrenClasses.Select(cc => cc.ChildrenId))
            .ToListAsync();

        var childrenNotEnrolled = parent.Children
            .Where(child => !classesInCourse.Contains(child.Id))
            .Select(child => new Child
            {
                Id = child.Id,
                ParentId = child.ParentId,
                FullName = child.FullName,
                Username = child.Username,
                Password = child.Password,
                ImgUrl = child.ImgUrl,
                BirthDay = child.BirthDay,
                Gender = child.Gender,
                Role = child.Role,
                Status = child.Status
            })
            .ToList();

        return childrenNotEnrolled;
    }
}
