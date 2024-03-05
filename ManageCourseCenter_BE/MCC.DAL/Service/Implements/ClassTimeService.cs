using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ClassDto;
using MCC.DAL.Dto.ClassTimeDto;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Service.Implements;

public class ClassTimeService : IClassTimeService
{
    private IClassTimeRepository _classTimeRepo;
    private IClassReposotory _classRepo;
    private IMapper _mapper;

    public ClassTimeService(IClassTimeRepository classTimeRepo, IClassReposotory classRepo, IMapper mapper)
    {
        _classTimeRepo = classTimeRepo;
        _classRepo = classRepo;
        _mapper = mapper;
    }

    public async Task<AppActionResult> CreateClassTimeAsync(ClassTimeCreateDto classTimeCreateDto)
    {
        var actionResult = new AppActionResult();
        
        var existingClass = await _classRepo.Entities().Include(c => c.ClassTimes).SingleOrDefaultAsync(c => c.Id == classTimeCreateDto.ClassId);
        if(existingClass == null)
        {
            return actionResult.BuildError("Not found class");
        }

        bool isValidClassTime = true;
        foreach(var lt in existingClass.ClassTimes)
        {
            if(lt.DayInWeek == classTimeCreateDto.DayInWeek && lt.StarTime == classTimeCreateDto.StarTime)
            {
                isValidClassTime = false;
                break;
            }
        }
        if(!isValidClassTime) 
        {
            return actionResult.BuildError("Invalid time");
        }
        try
        {
            var classTime = _mapper.Map<ClassTime>(classTimeCreateDto);
            await _classTimeRepo.AddAsync(classTime);
            await _classTimeRepo.SaveChangesAsync();
            return actionResult.BuildResult("Add success");
        } catch
        {
            return actionResult.BuildError("Add fail");
        }
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

    public async Task<AppActionResult> UpdateClassTimeAsync(ClassTimeUpdateDto classTimeUpdateDto)
    {
        var actionResult = new AppActionResult();

        var existingClass = await _classRepo.Entities().Include(c => c.ClassTimes).SingleOrDefaultAsync(c => c.Id == classTimeUpdateDto.ClassId);
        if (existingClass == null)
        {
            return actionResult.BuildError("Not found class");
        }

        bool isValidClassTime = true;
        foreach (var lt in existingClass.ClassTimes)
        {
            if (lt.Id != classTimeUpdateDto.Id && lt.DayInWeek == classTimeUpdateDto.DayInWeek && lt.StarTime == classTimeUpdateDto.StarTime)
            {
                isValidClassTime = false;
                break;
            }
        }
        if (!isValidClassTime)
        {
            return actionResult.BuildError("Invalid time");
        }
        try
        {
            var classTime = await _classTimeRepo.GetByIdAsync(classTimeUpdateDto.Id);
            classTime.ClassId = classTimeUpdateDto.ClassId;
            classTime.DayInWeek = classTimeUpdateDto.DayInWeek;
            classTime.StarTime = classTimeUpdateDto.StarTime;
            classTime.EndTime = classTimeUpdateDto.EndTime;
            _classTimeRepo.Update(classTime);
            await _classTimeRepo.SaveChangesAsync();
            return actionResult.BuildResult("Update success");
        }
        catch
        {
            return actionResult.BuildError("Update fail");
        }
    }
}
