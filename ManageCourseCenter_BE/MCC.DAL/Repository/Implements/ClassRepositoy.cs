using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class ClassRepositoy : RepositoryGeneric<Class>, IClassReposotory
{
    public ClassRepositoy(ManageCourseCenterContext context) : base(context)
    {
    }
}
