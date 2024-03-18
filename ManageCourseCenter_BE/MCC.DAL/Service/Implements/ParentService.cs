using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.CartDto;
using MCC.DAL.Dto.ChildDto;
using MCC.DAL.Dto.ParentDto;
using MCC.DAL.Dto.TeacherDto;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;
using static MCC.DAL.Service.Implements.CartService;
using System.Linq;

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
        var validDate = await _parentRepo
            .IsOlderThan18(parentCreateDto.BirthDay);

        if (!validDate)
        {
            return actionResult.BuildError("You must have older than 18 years old");
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

    public async Task<AppActionResult> GetAllChildrenByParentId(int parentId, int pageIndex, int pageSize)
    {
        var actionResult = new AppActionResult();
        var childrenQuery = await _parentRepo.GetAllChildFromParentIdAsync(parentId);

        var pagedChildren = await childrenQuery
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

        if (pagedChildren.Any())
        {
            return actionResult.BuildResult(pagedChildren);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }

    public async Task<AppActionResult> CreateChildrenWithParentID(int parentId, ChildCreatDto childCreateDto)
    {
        var actionResult = new AppActionResult();

        // Kiểm tra xem Parent có tồn tại không
        var parent = await _parentRepo.GetByIdAsync(parentId);
        if (parent == null)
        {
            return actionResult.BuildError("Parent not found");
        }
        // Check duplicate children full name of parent
        bool isExistingChildrenFullName = false;
        foreach (var child in parent.Children)
        {
            if (child.Username == childCreateDto.FullName)
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
            if (child.FullName == childCreateDto.FullName)
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
            // Tạo đối tượng Child mới và thêm thông tin của Parent
            var child = _mapper.Map<Child>(childCreateDto);
            child.ParentId = parentId; // Gán Parent ID

            await _parentRepo.AddChildAsync(child); // Giả sử có phương thức này trong repo
            await _parentRepo.SaveChangesAsync();

            return actionResult.SetInfo(true, "Add success");
        }
        catch (Exception ex)
        {
            return actionResult.BuildError("Add fail");
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
    public async Task<AppActionResult> CountNumberParent()
    {
        var actionResult = new AppActionResult();
        var data = await _parentRepo.GetAllAsync();
        int result = data.Count();
        return actionResult.BuildResult("Number Of Parent = " + result);
    }

    public enum ParentStatus
    {
        ACTIVE = 1,
        INACTIVE = 2
    } 
    public enum ParentGender
    {
        MALE = 1,
        FEMALE = 2
    }

    public async Task<AppActionResult> UpdateParentInformationAsync(ParentUpdateDto parentUpdateDto)
    {
        var actionResult = new AppActionResult();

        var existingParent = await _parentRepo.GetByIdAsync(parentUpdateDto.Id);
        if (existingParent == null)
        {
            return actionResult.BuildError("Parent is not existing");
        }

        //if field is not exist, dont't update this field
        if (!string.IsNullOrEmpty(parentUpdateDto.FullName))
        {
            existingParent.FullName = parentUpdateDto.FullName;
        }


        if (!string.IsNullOrEmpty(parentUpdateDto.Phone))
        {
            if (parentUpdateDto.Phone != existingParent.Phone)
            {
                var checkPhone = await _parentRepo.CheckExistingPhoneAsync(parentUpdateDto.Phone);
                if (!checkPhone)
                {
                    return actionResult.BuildError("Duplicate phone");
                }
            }
            existingParent.Phone = parentUpdateDto.Phone;
        }
        if (!string.IsNullOrEmpty(parentUpdateDto.Email))
        {
            if (parentUpdateDto.Email != existingParent.Email)
            {
                var checkEmail = await _parentRepo.CheckExistingEmailAsync(parentUpdateDto.Email);
                if (!checkEmail)
                {
                    return actionResult.BuildError("Duplicate email");
                }
            }
            existingParent.Email = parentUpdateDto.Email;
        }

        if(parentUpdateDto.BirthDay != existingParent.BirthDay)
        {
            var checkDay = await _parentRepo
                .IsOlderThan18(parentUpdateDto.BirthDay);

            if (!checkDay)
            {
                return actionResult.BuildError("You must have older than 18 years old");
            }

            existingParent.BirthDay = parentUpdateDto.BirthDay;
        }
        if (parentUpdateDto.BirthDay != default)
        {
            existingParent.BirthDay = parentUpdateDto.BirthDay;
        }

        if (parentUpdateDto.Gender != default)
        {
            existingParent.Gender = parentUpdateDto.Gender;
        }

      
        try
        {
            await _parentRepo.SaveChangesAsync();
            return actionResult.SetInfo(true, "Update success");
        }
        catch
        {
            return actionResult.BuildError("Update fail");
        }
    }

    public async Task<AppActionResult> UpdateChildrenOfAParent(int parentId, IEnumerable<ChildUpdateDto> childUpdates)
    {
        var actionResult = new AppActionResult();

        try
        {
            await _parentRepo.UpdateChildrenAsync(parentId, childUpdates);
            return actionResult.SetInfo(true, "Children updated successfully.");
        }
        catch (Exception ex)
        {
            // Handle exceptions appropriately
            return actionResult.BuildError("Failed to update children.");
        }
    }

}
