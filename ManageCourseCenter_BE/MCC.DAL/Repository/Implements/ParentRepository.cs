using MCC.DAL.Common;
using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ChildDto;
using MCC.DAL.Dto.ParentDto;
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

    // Validation method to check if BirthDay is older than 18 years old
    public async Task<bool> IsOlderThan18(DateTime birthday)
    {
        // Calculate age by subtracting BirthDay from current date
        int age = DateTime.Today.Year - birthday.Year;

        // Check if the birthday has occurred this year already
        if (birthday.Date > DateTime.Today.AddYears(-age)) 
            age--;

        // Return true if the person is older than 18
        return age >= 18;

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

    public async Task<IQueryable<Child>> GetAllChildFromParentIdAsync(int id)
    {
        return _dbSet
            .Where(p => p.Id == id)
            .SelectMany(p => p.Children)
            .AsQueryable();
    }

    public Task AddChildAsync(Child child)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateChildrenAsync(int parentId, IEnumerable<ChildUpdateDto> childUpdates)
    {
        var parent = await _dbSet.Include(p => p.Children).SingleOrDefaultAsync(p => p.Id == parentId);
        if (parent == null) throw new Exception("Parent not found.");

        foreach (var update in childUpdates)
        {
            var child = parent.Children.SingleOrDefault(c => c.Id == update.Id);
            if (child != null)
            {
                // Apply updates to each child
                child.FullName = update.FullName;
                // Update other properties as needed
            }
        }
        await _context.SaveChangesAsync();
    }

}
