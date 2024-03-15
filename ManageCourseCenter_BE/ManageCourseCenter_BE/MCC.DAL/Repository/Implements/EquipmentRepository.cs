using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class EquipmentRepository : RepositoryGeneric<Equipment>, IEquipmentRepository
{
    public EquipmentRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<bool> CheckExistingNameAsync(string name)
    {
        var existing = await _dbSet.SingleOrDefaultAsync(m => m.Name == name);
        if (existing == null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    public async Task<bool> UpdateEquipmentAsync(Equipment equipment)
    {
        try
        {
            _context.Equipment.Update(equipment);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> IsNameUniqueAsync(string name, int equipmentId)
    {
        return !await _dbSet.AnyAsync(e => e.Name == name && e.Id != equipmentId);
    }
}
