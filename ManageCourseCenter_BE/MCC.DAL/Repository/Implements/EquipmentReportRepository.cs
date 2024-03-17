using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class EquipmentReportRepository : RepositoryGeneric<EquipmentReport>, IEquipmentReportRepository
{
    public EquipmentReportRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public IQueryable<EquipmentReport> GetAllReportsByStatusAsync(int status)
    {
        return _context.EquipmentReports
                       .Where(r => r.Status == status);
    }

    public async Task<EquipmentReport> GetReportByIdAsync(int reportId)
    {
        return await _context.EquipmentReports.FirstOrDefaultAsync(r => r.Id == reportId);
    }

    public async Task UpdateAsync(EquipmentReport equipmentReport)
    {
        _context.EquipmentReports.Update(equipmentReport);
        await _context.SaveChangesAsync();
    }
}
