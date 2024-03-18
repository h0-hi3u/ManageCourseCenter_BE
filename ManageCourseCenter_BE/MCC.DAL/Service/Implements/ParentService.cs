using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ParentDto;
using MCC.DAL.Dto.TeacherDto;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Service.Implements;

public class ParentService : IParentService
{
    private IParentRepository _parentRepo;
    private IMapper _mapper;

    public ParentService(IParentRepository parentRepo, IMapper mapper)
    {
        _parentRepo = parentRepo;
        _mapper = mapper;
    }

    public async Task<AppActionResult> CreateParentAsync(ParentCreateDto parentCreateDto)
    {
        var actionResult = new AppActionResult();

        var checkEmail = await _parentRepo.CheckExistingEmailAsync(parentCreateDto.Email);
        if (!checkEmail)
        {
            return actionResult.BuildError("Duplicate email");
        }
        var checkPhone = await _parentRepo.CheckExistingPhoneAsync(parentCreateDto.Phone);
        if (!checkPhone)
        {
            return actionResult.BuildError("Duplicate phone");
        }
        try
        {
            var parent = _mapper.Map<Parent>(parentCreateDto);
            await _parentRepo.AddAsync(parent);
            await _parentRepo.SaveChangesAsync();
            return actionResult.SetInfo(true, "Add success");
        }
        catch
        {
            return actionResult.BuildError("Add fail");
        }
    }

    public async Task<AppActionResult> GetAllChildrenByParentId(int id)
    {
        var actionResult = new AppActionResult();
        var children = await _parentRepo.GetChildFromParentIdAsync(id);
        if (children != null)
        {
            return actionResult.BuildResult(children);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetAllParentAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _parentRepo.GetAllAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetChildWithParentEmail(string email)
    {
        var actionResult = new AppActionResult();
        var data = await _parentRepo.GetChildFromParentEmailAsync(email);
        if (data != null)
        {
            return actionResult.BuildResult(data);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetChildWithParentId(int id)
    {
        var actionResult = new AppActionResult();
        var data = await _parentRepo.GetChildFromParentIdAsync(id);
        if (data != null)
        {
            return actionResult.BuildResult(data);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetParentByEmailAndPasswordAsync(string email, string password)
    {
        var actionResult = new AppActionResult();
        var data = await _parentRepo.GetParentByEmailAndPasswordAsync(email, password);
        if (data != null)
        {
            return actionResult.BuildResult(data);
        } else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetParentByIdAsync(int id)
    {
        var actionResult = new AppActionResult();
        var data = await _parentRepo.GetByIdAsync(id);
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetParentByNameAsync(string name)
    {
        var actionResult = new AppActionResult();
        var data = await _parentRepo.Entities().Where(p => p.FullName.Contains(name)).ToListAsync();
        return actionResult.BuildResult(data);
    }
}
