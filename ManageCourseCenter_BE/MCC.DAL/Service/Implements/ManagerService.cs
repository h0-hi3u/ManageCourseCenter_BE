using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.Constants;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Service.Implements;

public class ManagerService : IManagerService
{
    private IManagerRepository _managerRepo;
    private IMapper _mapper;
    public ManagerService(IManagerRepository managerRepo, IMapper mapper)
    {
        _managerRepo = managerRepo;
        _mapper = mapper;
    }

    public async Task CreateAsync(Manager entity)
    {
        var checkEmail = await _managerRepo.CheckExistingEmailAsync(entity.Email);
        if (checkEmail)
        {
            await _managerRepo.AddAsync(entity);
            await _managerRepo.SaveChangesAsync();
        }
    }

    public async Task DeleteAsync(int id)
    {
        var exsiting = await _managerRepo.GetByIdAsync(id);
        if (exsiting != null)
        {
            _managerRepo.Delete(exsiting);
        }
    }

    public async Task<AppActionResult> GetAdminByIdAsync(int id)
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.Entities().SingleOrDefaultAsync(m => m.Role == RoleConstants.ADMIN && m.Id == id);
        if (data != null)
        {
            return actionResult.BuildResult(data);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetAdminByNameAsync(string name)
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.Entities().SingleOrDefaultAsync(m => m.Role == RoleConstants.ADMIN && m.FullName.Contains(name));
        if (data != null)
        {
            return actionResult.BuildResult(data);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetListAdminAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.Entities().Where(m => m.Role == RoleConstants.ADMIN).ToListAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetListManagerAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.Entities().Where(m => m.Role == RoleConstants.MANAGER).ToListAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetListStaffAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.Entities().Where(m => m.Role == RoleConstants.STAFF).ToListAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetManagerByEmailAndPasswordAsync(string email, string password)
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.getManagerByEmailAndPasswordAsync(email, password);
        if (data.Any())
        {
            return actionResult.BuildResult(data);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetManagerByIdAsync(int id)
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.Entities().SingleOrDefaultAsync(m => m.Role == RoleConstants.MANAGER && m.Id == id);
        if (data != null)
        {
            return actionResult.BuildResult(data);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetManagerByNameAsync(string name)
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.Entities().SingleOrDefaultAsync(m => m.Role == RoleConstants.MANAGER && m.FullName.Contains(name));
        if (data != null)
        {
            return actionResult.BuildResult(data);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetStaffByIdAsync(int id)
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.Entities().SingleOrDefaultAsync(m => m.Role == RoleConstants.STAFF && m.Id == id);
        if (data != null)
        {
            return actionResult.BuildResult(data);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetStaffByNameAsync(string name)
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.Entities().SingleOrDefaultAsync(m => m.Role == RoleConstants.STAFF && m.FullName.Contains(name));
        if (data != null)
        {
            return actionResult.BuildResult(data);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task UpdateAsync(Manager entity)
    {
        var existing = await _managerRepo.GetByIdAsync(entity.Id);
        if (existing != null)
        {
            existing.FullName = entity.FullName;
            existing.Email = entity.Email;
            existing.Phone = entity.Phone;
            existing.BirthDay = entity.BirthDay;
            existing.Gender = entity.Gender;
            existing.Role = entity.Role;
            existing.Status = entity.Status;
            _managerRepo.Update(existing);
            await _managerRepo.SaveChangesAsync();
        }

    }
}
