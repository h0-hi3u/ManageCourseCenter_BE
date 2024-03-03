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
}
