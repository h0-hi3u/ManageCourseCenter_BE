using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interfacep;

namespace MCC.DAL.Repository.Implements;

public class ChildRepository : RepositoryGeneric<Child>, IChildRepository
{
    public ChildRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
