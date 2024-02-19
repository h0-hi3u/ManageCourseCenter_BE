using MCC.DAL.DB.Models;
using MCC.DAL.EntityModels.Context;
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
        if(existing == null)
        {
            return true;
        } else
        {
            return false;
        }
    }
}
