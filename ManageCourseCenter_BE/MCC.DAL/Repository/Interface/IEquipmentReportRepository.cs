using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IEquipmentReportRepository : IRepositoryGeneric<EquipmentReport>
{
    IQueryable<EquipmentReport> GetAllReportsByStatusAsync(int status);
}
