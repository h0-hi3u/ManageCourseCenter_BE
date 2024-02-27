using AutoMapper;
using MCC.DAL.Common;
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
