using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ClassDto;
using MCC.DAL.Dto.CourceDto;
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
    private IMapper _mapper;

    public ClassService(IClassReposotory classRepo, ICourseRepository courseRepo, IMapper mapper)
    {
        _classRepo = classRepo;
        _courseRepo = courseRepo;
        _mapper = mapper;
    }

    public async Task<AppActionResult> CreateClassAsync(ClassCreateDto classCreateDto)
    {
        var actionResult = new AppActionResult();

        var checkName = await _classRepo.CheckExistingNameAsync(classCreateDto.Name);
        if (!checkName)
        {
            return actionResult.BuildError("Duplicate name");
        }

        try
        {
            var clas = _mapper.Map<Class>(classCreateDto);
            await _classRepo.AddAsync(clas);
            await _classRepo.SaveChangesAsync();
            return actionResult.SetInfo(true, "Add success");
        }
        catch
        {
            return actionResult.BuildError("Add fail");
        }
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
