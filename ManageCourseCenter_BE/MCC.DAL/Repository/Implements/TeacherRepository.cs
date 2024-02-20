using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class TeacherRepository : RepositoryGeneric<Teacher>, ITeacherRepository
{
    public TeacherRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
