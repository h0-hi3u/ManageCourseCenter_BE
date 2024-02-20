using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class ScheduleRepository : RepositoryGeneric<Schedule>, IScheduleRepository
{
    public ScheduleRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
