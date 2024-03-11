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
using System.Linq;

namespace MCC.DAL.Service.Implements;

public class ClassService : IClassService
{
    private IClassReposotory _classRepo;
    private ICourseRepository _courseRepo;
    private ITeacherRepository _teacherRepo;
    private IMapper _mapper;
    public static int PAGE_SIZE { get; set; } = 5;

    public ClassService(IClassReposotory classRepo, ICourseRepository courseRepo, IMapper mapper, ITeacherRepository teacherRepo)
    {
        _classRepo = classRepo;
        _courseRepo = courseRepo;
        _teacherRepo = teacherRepo;
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

    public async Task<AppActionResult> GetClassByTeacherIdAsync(int teacherId, int page = 1)
    {
        var actionResult = new AppActionResult();
        var data = await _teacherRepo.Entities().Include(c => c.Classes).SingleOrDefaultAsync(c => c.Id == teacherId);
        if(data != null)
        {
            return actionResult.BuildResult(data.Classes.Skip((page - 1) * PAGE_SIZE).Take(PAGE_SIZE));
        }
        else
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

    public async Task<AppActionResult> UpdateClassAsync(int classId, ClassUpdateDto classUpdateDto)
    {
        var actionResult = new AppActionResult();

        var _class = await _classRepo.GetByIdAsync(classId);
        if (_class == null)
        {
            return actionResult.BuildError("Class not found.");
        }

        if (!string.IsNullOrEmpty(classUpdateDto.Name) &&
            _class.Name != classUpdateDto.Name &&
            !(await _classRepo.IsNameUniqueAsync(classUpdateDto.Name, classId)))
        {
            return actionResult.BuildError("Class name already in use.");
        }

        _mapper.Map(classUpdateDto, _class);

        var success = await _classRepo.UpdateClassAsync(_class);
        if (!success)
        {
            return actionResult.BuildError("Failed to update class.");
        }
        return actionResult.BuildResult("Class updated successfully.");
    }
    public async Task<AppActionResult> CountNumberClass()
    {
        var actionResult = new AppActionResult();
        var data = await _classRepo.GetAllAsync();
        int result = data.Count();
        return actionResult.BuildResult("Number Of Class = " + result);
    }
}
