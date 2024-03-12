using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class AcademicTranscriptRepository : RepositoryGeneric<AcademicTranscript>, IAcademicTranscriptRepository
{
    public AcademicTranscriptRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<IEnumerable<AcademicTranscript>> getTranscriptByChildrenIDAsync(int childrenId)
    {
        return await _context.Set<AcademicTranscript>()
            .Include(t => t.Course)
            .Where(t => t.ChildrenId == childrenId)
            .ToListAsync();
    }

    public async Task<IEnumerable<AcademicTranscript>> getTranscriptByChildrenNameAsync(string childrenName)
    {
        return await _context.Set<AcademicTranscript>()
            .Include(t => t.Children)
            .Where(t => t.Children.FullName == childrenName)
            .ToListAsync();
    }

    public async Task<IEnumerable<AcademicTranscript>> getTranscriptByChildrenNameAndCourseNameAsync(string childrenName, string courseName)
    {
        return await _context.Set<AcademicTranscript>()
            .Include(t => t.Children)
            .Include(t => t.Course)
            .Where(t => t.Children.FullName.Contains(childrenName) && t.Course.Name.Contains(courseName))
            .ToListAsync();
    }

    public async Task<IEnumerable<AcademicTranscript>> getTranscriptByTeacherIDAsync(int teacherId)
    {
        return await _context.Set<AcademicTranscript>()
            .Where(t => t.TeacherId == teacherId)
            .ToListAsync();
    }

    public async Task<IEnumerable<AcademicTranscript>> getTranscriptByTeacherNameAsync(string teacherName)
    {
        return await _context.Set<AcademicTranscript>()
            .Include(t => t.Teacher)
            .Where(t => t.Teacher.FullName == teacherName)
            .ToListAsync();
    }

    public async Task<bool> UpdateAcademicTranscriptAsync(AcademicTranscript academicTranscript)
    {
        try
        {
            _context.AcademicTranscripts.Update(academicTranscript);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
