using AutoMapper;
using MCC.DAL.Authentication;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ChildDto;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Repository.Interfacep;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Service.Implements;

public class ChildService : IChildService
{
    private IChildRepository _childRepo;
    private IParentRepository _parentRepo;
    private IMapper _mapper;
    private IAuthService _authService;

    public ChildService(IChildRepository childRepo, IParentRepository parentRepo, IMapper mapper, IAuthService authService)
    {
        _childRepo = childRepo;
        _parentRepo = parentRepo;
        _mapper = mapper;
        _authService = authService;
    }

    public async Task<AppActionResult> Authenticate(string username, string password)
    {
        var child = await _childRepo.GetChildrenByUsernameAndPassword(username, password);
        if (child == null)
        {
            return new AppActionResult().BuildError("Authentication failed");
        }

        var token = _authService.GenerateJwtToken(child);

        return new AppActionResult().BuildResult(token);
    }

    public async Task<AppActionResult> CreateChildAsync(ChildCreatDto childCreatDto)
    {
        var actionResult = new AppActionResult();
        var parent = await _parentRepo.Entities().Include(p => p.Children).SingleOrDefaultAsync(p => p.Id == childCreatDto.ParentId);
        if(parent == null)
        {
            return actionResult.BuildError("Not found parent");
        }
        // Check duplicate children full name of parent
        bool isExistingChildrenFullName = false;
        foreach(var child in parent.Children)
        {
            if(child.FullName == childCreatDto.FullName)
            {
                isExistingChildrenFullName = true;
                break;
            }
        }
        if(isExistingChildrenFullName)
        {
            return actionResult.BuildError("Children full name existing");
        }
        // Check duplicate children username of parent
        bool isExistingChildrenUserName = false;
        foreach (var child in parent.Children)
        {
            if (child.Username == childCreatDto.Username)
            {
                isExistingChildrenUserName = true;
                break;
            }
        }
        if (isExistingChildrenUserName)
        {
            return actionResult.BuildError("Children user name existing");
        }
        try
        {
            var children = _mapper.Map<Child>(childCreatDto);
            await _childRepo.AddAsync(children);
            await _childRepo.SaveChangesAsync();
            return actionResult.BuildResult("Add success");
        } catch
        {
            return actionResult.BuildError("Add fail");
        }
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

    public async Task<AppActionResult> GetChildrenByUsernameAndPasswordAsync(string username, string password)
    {
        var actionResult = new AppActionResult();
        var existing = await _childRepo.GetChildrenByUsernameAndPassword(username, password);
        if (existing != null)
        {
            return actionResult.BuildResult(existing);
        } else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> UpdateChildAsync(ChildUpdateDto childUpdateDto)
    {
        var actionResult = new AppActionResult();
        var parent = await _parentRepo.Entities().Include(p => p.Children).SingleOrDefaultAsync(p => p.Id == childUpdateDto.ParentId);
        if (parent == null)
        {
            return actionResult.BuildError("Not found parent");
        }
        // Check duplicate children full name of parent
        bool isExistingChildrenFullName = false;
        foreach (var child in parent.Children)
        {
            if (child.FullName == childUpdateDto.FullName && child.Id != childUpdateDto.Id)
            {
                isExistingChildrenFullName = true;
                break;
            }
        }
        if (isExistingChildrenFullName)
        {
            return actionResult.BuildError("Children full name existing");
        }
        // Check duplicate children username of parent
        bool isExistingChildrenUserName = false;
        foreach (var child in parent.Children)
        {
            if (child.Username == childUpdateDto.Username && child.Id != childUpdateDto.Id)
            {
                isExistingChildrenUserName = true;
                break;
            }
        }
        if (isExistingChildrenUserName)
        {
            return actionResult.BuildError("Children user name existing");
        }
        try
        {
            var child = await _childRepo.GetByIdAsync(childUpdateDto.Id);
            child.Id = childUpdateDto.Id;
            child.ParentId = childUpdateDto.ParentId;
            child.FullName = childUpdateDto.FullName;
            child.Username = childUpdateDto.Username;
            child.Password = childUpdateDto.Password;
            child.ImgUrl = childUpdateDto.ImgUrl;
            child.BirthDay = childUpdateDto.BirthDay;
            child.Gender = childUpdateDto.Gender;
            child.Role = childUpdateDto.Role;
            child.Status = childUpdateDto.Status;
            _childRepo.Update(child);
            await _childRepo.SaveChangesAsync();
            return actionResult.BuildResult("Update success");
        }
        catch
        {
            return actionResult.BuildError("Update fail");
        }
    }
    public async Task<AppActionResult> CountNumberChildrent()
    {
        var actionResult = new AppActionResult();
        var data = await _childRepo.GetAllAsync();
        int result = data.Count();
        if (result > 0)
        {
            return actionResult.BuildResult("Number Of Childrent = " + result);
        }
        else
        {
            return actionResult.BuildError("No Childrent");
        }
    }
}
