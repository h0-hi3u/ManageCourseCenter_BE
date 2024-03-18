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
}
