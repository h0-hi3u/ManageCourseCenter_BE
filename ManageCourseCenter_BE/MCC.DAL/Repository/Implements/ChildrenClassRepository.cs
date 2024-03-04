using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Repository.Implements;

public class ChildrenClassRepository : RepositoryGeneric<ChildrenClass>, IChildrenClassRepository
{
    public ChildrenClassRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<IEnumerable<ChildrenClass>> GetChildrenClassByChildrenIDAsync(int childrenId)
    {
        return await _context.Set<ChildrenClass>()
            .Where(c => c.ChildrenId == childrenId)
            .ToListAsync();
    }

    public async Task<IEnumerable<ChildrenClass>> GetChildrenClassByClassIDAsync(int classId)
    {
        return await _context.Set<ChildrenClass>()
            .Where(c => c.ClassId == classId)
            .ToListAsync();
    }

    public async Task<IEnumerable<ChildrenClass>> GetChildrenClassByClassNameAsync(string className)
    {
        return await _context.Set<ChildrenClass>()
            .Include(c => c.Class)
            .Where(c => c.Class.Name == className)
            .ToListAsync();
    }

    public async Task<IEnumerable<ChildrenClass>> GetChildrensClassByChildrenNameAsync(string childrenName)
    {
        return await _context.Set<ChildrenClass>()
            .Include(c => c.Children)
            .Where(c => c.Children.FullName == childrenName)
            .ToListAsync();
    }
}
