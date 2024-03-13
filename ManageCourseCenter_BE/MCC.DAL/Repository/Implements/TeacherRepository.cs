using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class TeacherRepository : RepositoryGeneric<Teacher>, ITeacherRepository
{
    public TeacherRepository(ManageCourseCenterContext context) : base(context)
    {
    }
    public async Task<bool> CheckExistingEmailAsync(string email)
    {
        var existing = await _dbSet.SingleOrDefaultAsync(m => m.Email == email);
        if (existing == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> CheckExistingPhoneAsync(string phone)
    {
        var existing = await _dbSet.SingleOrDefaultAsync(m => m.Phone == phone);
        if (existing == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<Teacher> GetTeacherByEmailAndPasswordAsync(string email, string password)
    {
        return await _dbSet.SingleOrDefaultAsync(t => t.Email == email && t.Password == password && t.Status == 1);
    }

    public async Task<bool> UpdateTeacherAsync(Teacher teacher)
    {
        try
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> IsEmailUniqueAsync(string email, int? teacherId = null)
    {
        return !await _context.Teachers.AnyAsync(t => t.Email == email && t.Id != teacherId);
    }

    public async Task<bool> IsPhoneUniqueAsync(string phone, int? teacherId = null)
    {
        return !await _context.Teachers.AnyAsync(t => t.Phone == phone && t.Id != teacherId);
    }

    public async Task<bool> ChangePasswordAsync(int teacherId, string newPassword)
    {
        var teacher = await _context.Teachers.FindAsync(teacherId);
        if (teacher == null)
        {
            return false;
        }

        teacher.Password = newPassword;
        _context.Teachers.Update(teacher);
        return await _context.SaveChangesAsync() > 0;
    }
}
