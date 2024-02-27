using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Service.Implements;

public class CourseService : ICourseService
{
    private ICourseRepository _courseRepo;

    public CourseService(ICourseRepository courseRepo)
    {
        _courseRepo = courseRepo;
    }

    public async Task<AppActionResult> GetAllCoureAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _courseRepo.GetAllAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetCourseByIdAsync(int id)
    {
        var actionResult = new AppActionResult();
        var data = await _courseRepo.GetByIdAsync(id);
        if(data != null)
        {
            return actionResult.BuildResult(data);
        } else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetCourseByNameAsync(string name)
    {
        var actionResult = new AppActionResult();
        var data = await _courseRepo.GetCourseByNameAsync(name);
        return actionResult.BuildResult(data);
    }
}
