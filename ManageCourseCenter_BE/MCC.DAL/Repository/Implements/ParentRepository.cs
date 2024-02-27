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
}
