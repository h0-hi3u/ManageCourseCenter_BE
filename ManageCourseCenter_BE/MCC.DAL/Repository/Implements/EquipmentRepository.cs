using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class EquipmentRepository : RepositoryGeneric<Equipment>, IEquipmentRepository
{
    public EquipmentRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
