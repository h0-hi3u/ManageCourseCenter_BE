using MCC.DAL.DB.Models;
using MCC.DAL.DB.Context;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using MCC.DAL.Constants;
using MCC.DAL.Common;
using MCC.DAL.Dto.ManagerDto;

namespace MCC.DAL.Repository.Implements;

public class ManagerRepository : RepositoryGeneric<Manager>, IManagerRepository
{
    public ManagerRepository(ManageCourseCenterContext context) : base(context)
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
    public async Task<Manager> GetStaffByUsernameAndPassword(string username, string password)
    {
        return await _dbSet.SingleOrDefaultAsync(c => c.Email == username && c.Password == password && c.Role == CoreConstants.ROLE_STAFF);
    }
    public async Task<Manager> GetAdminByUsernameAndPassword(string username, string password)
    {
        return await _dbSet.SingleOrDefaultAsync(c => c.Email == username && c.Password == password && c.Role == CoreConstants.ROLE_ADMIN);
    }
    public async Task<Manager> GetManagerByEmailAndPasswordAsync(string email, string password)
    {
        return  await _dbSet.SingleOrDefaultAsync(t => t.Email == email && t.Password == password && t.Role == CoreConstants.ROLE_MANAGER);
    }

    public async Task<bool> ChangePasswordStaffAsync(int managerId, string newPassword)
    {
        var staff = await _context.Managers.FindAsync(managerId);
        if (staff == null || staff.Role != CoreConstants.ROLE_STAFF)
        {
            return false;
        }

        staff.Password = newPassword;
        _context.Managers.Update(staff);
        return await _context.SaveChangesAsync() > 0;
    }

}
