using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Implements;

public class TeacherService : ITeacherService
{
    private ITeacherRepository _teacherRepo;
    private IMapper _mapper;

    public TeacherService(ITeacherRepository teacherRepo, IMapper mapper)
    {
        _teacherRepo = teacherRepo;
        _mapper = mapper;
    }

    public async Task<AppActionResult> GetAllTeacherAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _teacherRepo.GetAllAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetTeachByIdAsync(int id)
    {
        var actionResult = new AppActionResult();
        var data = await _teacherRepo.GetByIdAsync(id);
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetTeachByNameAsync(string name)
    {
        var actionResult = new AppActionResult();
        var data = await _teacherRepo.Entities().Where(t => t.FullName.Contains(name)).ToListAsync();
        return actionResult.BuildResult(data);
    }
}
