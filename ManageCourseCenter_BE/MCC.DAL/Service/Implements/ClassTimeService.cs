using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Implements;

public class ClassTimeService : IClassTimeService
{
    private IClassTimeRepository _classTimeRepo;
    private IClassReposotory _classRepo;

    public ClassTimeService(IClassTimeRepository classTimeRepo, IClassReposotory classRepo)
    {
        _classTimeRepo = classTimeRepo;
        _classRepo = classRepo;
    }

    public async Task<AppActionResult> GetClassTimeByClassIdAsync(int classId)
    {
        var actionResult = new AppActionResult();
        var exsiting = await _classRepo.GetByIdAsync(classId);
        if(exsiting == null)
        {
            return actionResult.BuildError("Not found");
        }
        var data = await _classTimeRepo.GetClassTimeByClassIdAsync(classId);
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetClassTimeByClassName(string className)
    {
        var actionResult = new AppActionResult();
        var exsiting = await _classRepo.GetClassByNameAsync(className);
        if (exsiting == null)
        {
            return actionResult.BuildError("Not found");
        }
        var data = await _classTimeRepo.GetClassTimeByClassNameAsync(className);
        return actionResult.BuildResult(data);
    }
}
