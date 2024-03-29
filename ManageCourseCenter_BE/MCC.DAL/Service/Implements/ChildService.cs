﻿using AutoMapper;
using MCC.DAL.Authentication;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto;
using MCC.DAL.Dto.ChildDto;
using MCC.DAL.Repository.Implements;
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
    private IClassReposotory _classRepo;
    private readonly ICourseRepository _courseRepository;

    public ChildService(IChildRepository childRepo, IParentRepository parentRepo, IMapper mapper, IAuthService authService, ICourseRepository courseRepository, IClassReposotory classReposotory)
    {
        _childRepo = childRepo;
        _parentRepo = parentRepo;
        _mapper = mapper;
        _authService = authService;
        _courseRepository = courseRepository;
        _classRepo = classReposotory;
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

    public async Task<AppActionResult> GetAllChildPagingAsync(int pageSize, int pageIndex)
    {
        var actionResult = new AppActionResult();
        PagingDto pagingDto = new PagingDto();
        var skip = CalculateHelper.CalculatePaging(pageSize, pageIndex);
        List<Child> listChild = new List<Child>();

        var data = await _childRepo.GetAllAsync();
        listChild.AddRange(data);

        var totalRecords = listChild.Count;
        var result = listChild.Skip(skip).Take(pageSize).ToList();

        pagingDto.TotalRecords = totalRecords;
        pagingDto.Data = result;
        return actionResult.BuildResult(pagingDto);
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
    public async Task<AppActionResult> GetAllChildByClassId(int classId)
    {
        var actionResult = new AppActionResult();
        var listClass = await _classRepo
            .Entities()
            .Include(c => c.ChildrenClasses)
            .Include(c => c.Course)
            .Where(c => c.Id == classId)
            .ToListAsync();
        List<int> listId = new List<int>();
        foreach(var item in listClass)
        {
            var temp = item.ChildrenClasses.Select(cc => cc.ChildrenId);
            listId.AddRange(temp);
        }
        listId.Distinct();
        List<Child> listChild = new List<Child>();
        foreach(var id in listId)
        {
            var temp = await _childRepo
                .Entities()
                .Include(c => c.ChildrenClasses)
                .Where(cc => cc.Id == id)
                .ToListAsync();
            listChild.AddRange(temp);
        }
        return actionResult.BuildResult(listChild);
    }

    public async Task<AppActionResult> GetChildrenListNotEnrollCourseAsync(int parentId, int courseId, int pageIndex, int pageSize)
    {
        var actionResult = new AppActionResult();

        var parentExist = await _parentRepo.GetByIdAsync(parentId);
        if (parentExist == null)
        {
            return actionResult.BuildError("Parent not found");
        }

        var courseExist = await _courseRepository.GetByIdAsync(courseId);
        if (courseExist == null)
        {
            return actionResult.BuildError("Course not found");
        }

        var childrenListQuery = await _childRepo.GetChildrenListNotEnrollCourseAsync(parentId, courseId);

        if (childrenListQuery == null)
        {
            return actionResult.BuildError("No children found");
        }

        var pagedChildren = childrenListQuery
            .Skip((pageIndex - 1) * pageSize)
            .Take(pageSize)
            .ToList();

        if (pagedChildren.Any())
        {
            return actionResult.BuildResult(pagedChildren);
        }
        else
        {
            return actionResult.BuildError("Not found");
        }
    }
}
