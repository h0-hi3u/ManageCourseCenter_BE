using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.Repository.Interfacep;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Service.Implements;

public class ChildService : IChildService
{
    private IChildRepository _childRepo;
    private IMapper _mapper;

    public ChildService(IChildRepository childRepo, IMapper mapper)
    {
        _childRepo = childRepo;
        _mapper = mapper;
    }

    public async Task<AppActionResult> GetAllChildAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _childRepo.GetAllAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetChildByIdAsync(int id)
    {
        var actionResult = new AppActionResult();
        var data = await _childRepo.GetByIdAsync(id);
        if (data != null)
        {
            return actionResult.BuildResult(data);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetChildByNameAsync(string name)
    {
        var actionResult = new AppActionResult();
        var data = await _childRepo.Entities().Where(c => c.FullName.Contains(name)).ToListAsync();
        return actionResult.BuildResult(data);
    }
}
