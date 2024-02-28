using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Implements;

public class ClassService : IClassService
{
    private IClassReposotory _classRepo;
    private ICourseRepository _courseRepo;

    public ClassService(IClassReposotory classRepo, ICourseRepository courseRepo)
    {
        _classRepo = classRepo;
        _courseRepo = courseRepo;
    }

    public async Task<AppActionResult> GetAllClassAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _classRepo.GetAllAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetClassByCourseIdAsync(int courseId)
    {
        var actionResult = new AppActionResult();
        var data = await _courseRepo.Entities().Include(c => c.Classes).SingleOrDefaultAsync(c => c.Id == courseId);
        if(data != null)
        {
            return actionResult.BuildResult(data.Classes);
        } else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetClassByCourseNameAsync(string courseName)
    {
        var actionResult = new AppActionResult();
        var data = await _courseRepo.Entities().Include(c => c.Classes).SingleOrDefaultAsync(c => c.Name == courseName);
        if (data != null)
        {
            return actionResult.BuildResult(data.Classes);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetClassByIdAsync(int id)
    {
        var actionResult = new AppActionResult();
        var data = await _classRepo.GetByIdAsync(id);
        if (data != null)
        {
            return actionResult.BuildResult(data);
        } else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetClassByNameAsync(string name)
    {
        var actionResult = new AppActionResult();
        var data = await _classRepo.GetCourseByNameAsync(name);
        return actionResult.BuildResult(data);
    }
}
