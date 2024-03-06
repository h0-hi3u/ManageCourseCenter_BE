using MCC.DAL.DB.Models;
using MCC.DAL.DB.Context;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

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

    public async Task<IEnumerable<Manager>> getManagerByEmailAndPasswordAsync(string email, string password)
    {
        var manager = await _dbSet.Where(t => t.Email == email && t.Password == password).ToListAsync();

        return manager;
    }
}
