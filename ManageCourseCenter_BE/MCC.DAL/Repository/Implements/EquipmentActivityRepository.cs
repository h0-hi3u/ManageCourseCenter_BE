using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class EquipmentActivityRepository : RepositoryGeneric<EquipmenntActivity>, IEquipmentActivityRepository
{
    public EquipmentActivityRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
