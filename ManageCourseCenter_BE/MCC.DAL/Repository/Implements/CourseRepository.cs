using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class CourseRepository : RepositoryGeneric<Course>, ICourseRepository
{
    public CourseRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
