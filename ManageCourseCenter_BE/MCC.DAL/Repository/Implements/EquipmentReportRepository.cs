using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class EquipmentReportRepository : RepositoryGeneric<EquipmentReport>, IEquipmentReportRepository
{
    public EquipmentReportRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
