using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class ClassTimeRepository : RepositoryGeneric<ClassTime>, IClassTimeRepository
{
    public ClassTimeRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
