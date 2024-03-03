using MCC.DAL.Common;
using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class ParentRepository : RepositoryGeneric<Parent>, IParentRepository
{
    public ParentRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<Parent> LoginAsync(string email, string password)
    {
        var existing = await _dbSet.SingleOrDefaultAsync(p => p.Email == email && p.Password == password);
        if (existing != null)
        {
            return existing;
        } else
        {
            return null;
        }
    }
    public async Task<IEnumerable<Child>> GetChildFromParentIdAsync(int id)
    {
        var parent = await _dbSet.Include(p => p.Children).SingleOrDefaultAsync(p => p.Id == id);
        if (parent != null)
        {
            return parent.Children;
        } else
        {
            return null;
        }
    }

    public async Task<IEnumerable<Child>> GetChildFromParentEmailAsync(string email)
    {
        var parent = await _dbSet.Include(p => p.Children).SingleOrDefaultAsync(p => p.Email == email);
        if (parent != null)
        {
            return parent.Children;
        }
        else
        {
            return null;
        }
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

    public async Task<Parent> GetParentByEmailAndPasswordAsync(string email, string password)
    {
        return await _dbSet.SingleOrDefaultAsync(p => p.Email == email && p.Password == password && p.Status == 1);
    }
}
