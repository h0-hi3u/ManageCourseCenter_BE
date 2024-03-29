﻿using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.Constants;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ManagerDto;
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

    public async Task<AppActionResult> CreateAsync(ManagerCreateDto entity)
    {
        var actionResult = new AppActionResult();

        var checkEmail = await _managerRepo.CheckExistingEmailAsync(entity.Email);
        if (!checkEmail)
        {
            return actionResult.BuildError("Duplicate email");
        }
        var checkPhone = await _managerRepo.CheckExistingPhoneAsync(entity.Phone);
        if (!checkPhone)
        {
            return actionResult.BuildError("Duplicate phone");
        }
        try
        {
            var manager = _mapper.Map<Manager>(entity);
            await _managerRepo.AddAsync(manager);
            await _managerRepo.SaveChangesAsync();
            return actionResult.SetInfo(true, "Add success");
        }
        catch
        {
            return actionResult.BuildError("Add fail");
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
        var data = await _managerRepo.Entities().SingleOrDefaultAsync(m => m.Role == CoreConstants.ROLE_ADMIN && m.Id == id);
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
        var data = await _managerRepo.Entities().SingleOrDefaultAsync(m => m.Role == CoreConstants.ROLE_ADMIN && m.FullName.Contains(name));
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
        var data = await _managerRepo.Entities().Where(m => m.Role == CoreConstants.ROLE_ADMIN).ToListAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetListManagerAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.Entities().Where(m => m.Role == CoreConstants.ROLE_MANAGER).ToListAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetListStaffAsync()
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.Entities().Where(m => m.Role == CoreConstants.ROLE_STAFF).ToListAsync();
        return actionResult.BuildResult(data);
    }

    public async Task<AppActionResult> GetManagerByEmailAndPasswordAsync(string email, string password)
    {
        var actionResult = new AppActionResult();
        var data = await _managerRepo.GetManagerByEmailAndPasswordAsync(email, password);
        if (data != null)
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
        var data = await _managerRepo.Entities().SingleOrDefaultAsync(m => m.Role == CoreConstants.ROLE_MANAGER && m.Id == id);
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
        var data = await _managerRepo.Entities().SingleOrDefaultAsync(m => m.Role == CoreConstants.ROLE_MANAGER && m.FullName.Contains(name));
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
        var data = await _managerRepo.Entities().SingleOrDefaultAsync(m => m.Role == CoreConstants.ROLE_STAFF && m.Id == id);
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
        var data = await _managerRepo.Entities().SingleOrDefaultAsync(m => m.Role == CoreConstants.ROLE_STAFF && m.FullName.Contains(name));
        if (data != null)
        {
            return actionResult.BuildResult(data);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }


    public async Task<AppActionResult> UpdateAsync(ManagerUpdateDto managerUpdateDto)
    {
        var actionResult = new AppActionResult();
        // check manager is existing
        var existing = await _managerRepo.GetByIdAsync(managerUpdateDto.Id);
        if (existing == null)
        {
            return actionResult.BuildError("Not found");
        }
        var listManager = await _managerRepo.Entities().ToListAsync();
        listManager.Remove(existing);
        // check duplicate email
        bool checkEmail = listManager.SingleOrDefault(m => m.Email == managerUpdateDto.Email) == null ? true : false;
        if (!checkEmail)
        {
            return actionResult.BuildError("Duplicate email");
        }
        // check duplicate phone
        bool checkPhone = listManager.SingleOrDefault(m => m.Phone == managerUpdateDto.Phone) == null ? true : false;
        if (!checkPhone)
        {
            return actionResult.BuildError("Duplicate phone");
        }

        try
        {
            existing.FullName = managerUpdateDto.FullName;
            existing.Email = managerUpdateDto.Email;
            existing.Phone = managerUpdateDto.Phone;
            existing.BirthDay = managerUpdateDto.BirthDay;
            existing.Gender = managerUpdateDto.Gender;
            existing.Role = managerUpdateDto.Role;
            existing.Status = managerUpdateDto.Status;
            _managerRepo.Update(existing);
            await _managerRepo.SaveChangesAsync();
            return actionResult.BuildResult("Update success");
        }
        catch
        {
            return actionResult.BuildError("Add fail");
        }

    }
    //public async Task<AppActionResult> GetChildrenByUsernameAndPasswordAsync(string username, string password)
    //{
    //    var actionResult = new AppActionResult();
    //    var existing = await _childRepo.GetChildrenByUsernameAndPassword(username, password);
    //    if (existing != null)
    //    {
    //        return actionResult.BuildResult(existing);
    //    }
    //    else
    //    {
    //        return actionResult.BuildError("Not found");
    //    }
    //}
    public async Task<AppActionResult> GetManagerByUsernameAndPasswordAsync(string username, string password)
    {
        var actionResult = new AppActionResult();
        var existing = await _managerRepo.GetManagerByEmailAndPasswordAsync(username, password);
        if (existing != null)
        {
            return actionResult.BuildResult(existing);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetStaffByUsernameAndPasswordAsync(string username, string password)
    {
        var actionResult = new AppActionResult();
        var existing = await _managerRepo.GetStaffByUsernameAndPassword(username, password);
        if (existing != null)
        {
            return actionResult.BuildResult(existing);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> GetAdminByUsernameAndPasswordAsync(string username, string password)
    {
        var actionResult = new AppActionResult();
        var existing = await _managerRepo.GetAdminByUsernameAndPassword(username, password);
        if (existing != null)
        {
            return actionResult.BuildResult(existing);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> ChangePasswordStaffAsync(int staffId, StaffChangePasswordDto dto)
    {
        var actionResult = new AppActionResult();
        var staff = await _managerRepo.GetByIdAsync(staffId);

        if (staff == null)
        {
            return actionResult.BuildError("Staff not found.");
        }

        if (staff.Role != CoreConstants.ROLE_STAFF)
        {
            return actionResult.BuildError("Not authorized.");
        }

        if (staff.Password != dto.CurrentPassword)
        {
            return actionResult.BuildError("Current password is incorrect.");
        }

        var success = await _managerRepo.ChangePasswordStaffAsync(staffId, dto.NewPassword);
        if (!success)
        {
            return actionResult.BuildError("Failed to change the password.");
        }

        return actionResult.BuildResult("Password changed successfully.");
    }

    public async Task<AppActionResult> UpdateStaffInformationAsync(int managerId, StaffUpdateDto staffUpdateDto)
    {
        var staff = await _managerRepo.GetByIdAsync(managerId);
        var result = new AppActionResult();

        if (staff == null)
        {
            return result.BuildError("Manager not found.");
        }

        if (staff.Role != CoreConstants.ROLE_STAFF)
        {
            return result.BuildError("The specified ID does not belong to a staff member.");
        }

        _mapper.Map(staffUpdateDto, staff);

        _managerRepo.Update(staff);
        await _managerRepo.SaveChangesAsync();

        return result.BuildResult("Staff information updated successfully.");
    }

    public async Task<AppActionResult> SetStatusStaffAsync(int staffId, StaffSetStatusDto statusDto)
    {
        var staff = await _managerRepo.GetByIdAsync(staffId);
        var result = new AppActionResult();

        if (staff == null)
        {
            return result.BuildError("Staff not found.");
        }

        if (staff.Role != CoreConstants.ROLE_STAFF)
        {
            return result.BuildError("The specified ID does not belong to a staff member.");
        }

        _mapper.Map(statusDto, staff);

        _managerRepo.Update(staff);
        await _managerRepo.SaveChangesAsync();

        return result.BuildResult("Staff status updated successfully.");
    }
}
