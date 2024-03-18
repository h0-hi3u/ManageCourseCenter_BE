using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.TeacherDto;
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

    public async Task<AppActionResult> ChangePasswordTeacherAsync(int teacherId, TeacherChangePasswordDto teacherChangePasswordDto)
    {
        var actionResult = new AppActionResult();
        var teacher = await _teacherRepo.GetByIdAsync(teacherId);

        if (teacher == null)
        {
            return actionResult.BuildError("Teacher not found.");
        }

        if (teacher.Password != teacherChangePasswordDto.CurrentPassword) 
        {
            return actionResult.BuildError("Current password is incorrect.");
        }

        var success = await _teacherRepo.ChangePasswordAsync(teacherId, teacherChangePasswordDto.NewPassword);
        if (!success)
        {
            return actionResult.BuildError("Failed to change the password.");
        }

        return actionResult.BuildResult("Password changed successfully.");
    }

    public async Task<AppActionResult> CreateTeacherAsync(TeacherCreateDto teacherCreateDto)
    {
        var actionResult = new AppActionResult();

        var checkEmail = await _teacherRepo.CheckExistingEmailAsync(teacherCreateDto.Email);
        if (!checkEmail)
        {
            return actionResult.BuildError("Duplicate email");
        }
        var checkPhone = await _teacherRepo.CheckExistingPhoneAsync(teacherCreateDto.Phone);
        if (!checkPhone)
        {
            return actionResult.BuildError("Duplicate phone");
        }
        try
        {
            var teacher = _mapper.Map<Teacher>(teacherCreateDto);
            await _teacherRepo.AddAsync(teacher);
            await _teacherRepo.SaveChangesAsync();
            return actionResult.SetInfo(true, "Add success");
        }
        catch
        {
            return actionResult.BuildError("Add fail");
        }
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

    public async Task<AppActionResult> GetTeacherByEmailAndPasswordAsync(string email, string password)
    {
        var actionResult = new AppActionResult();
        var data = await _teacherRepo.GetTeacherByEmailAndPasswordAsync(email, password);
        if(data == null)
        {
            return actionResult.BuildError("Not found");
        } else
        {
            return actionResult.BuildResult(data);
        }
    }

    public async Task<AppActionResult> SetTeacherStatusAsync(TeacherStatusSetDto teacherStatusSetDto)
    {
        var actionResult = new AppActionResult();

        var teacher = await _teacherRepo.GetByIdAsync(teacherStatusSetDto.Id);
        if (teacher == null)
        {
            return actionResult.BuildError("Teacher not found.");
        }

        _mapper.Map(teacherStatusSetDto, teacher);

        try
        {
            await _teacherRepo.UpdateTeacherAsync(teacher);
            return actionResult.BuildResult("Status update success");
        }
        catch (Exception ex)
        {
            return actionResult.BuildError($"Status update fail: {ex.Message}");
        }
    }

    public async Task<AppActionResult> UpdateTeacherAsync(int teacherId, TeacherUpdateDto teacherUpdateDto)
    {
        var actionResult = new AppActionResult();

        var teacher = await _teacherRepo.GetByIdAsync(teacherId);
        if (teacher == null)
        {
            return actionResult.BuildError("Teacher not found.");
        }

        if (!string.IsNullOrEmpty(teacherUpdateDto.Email) &&
            teacher.Email != teacherUpdateDto.Email &&
            !(await _teacherRepo.IsEmailUniqueAsync(teacherUpdateDto.Email, teacherId)))
        {
            return actionResult.BuildError("Email already in use by another teacher.");
        }

        if (!string.IsNullOrEmpty(teacherUpdateDto.Phone) &&
            teacher.Phone != teacherUpdateDto.Phone &&
            !(await _teacherRepo.IsPhoneUniqueAsync(teacherUpdateDto.Phone, teacherId)))
        {
            return actionResult.BuildError("Phone already in use by another teacher.");
        }

        _mapper.Map(teacherUpdateDto, teacher);

        bool success = await _teacherRepo.UpdateTeacherAsync(teacher);
        if (!success)
        {
            return actionResult.BuildError("Failed to update teacher information.");
        }

        return actionResult.BuildResult("Teacher updated successfully.");
    }
}

