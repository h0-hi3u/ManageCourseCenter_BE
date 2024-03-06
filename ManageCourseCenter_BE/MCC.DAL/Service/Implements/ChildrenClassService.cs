using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.ChildrenClassDto;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Repository.Interfacep;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Implements
{
    public class ChildrenClassService : IChildrenClassService
    {
        private IChildRepository _childRepo;
        private IClassReposotory _classRepo;
        private IChildrenClassRepository _childrenClassRepo;
        private IMapper _mapper;

        public ChildrenClassService(IClassReposotory classRepo, IChildRepository childRepository, IChildrenClassRepository childrenClassRepository, IMapper mapper)
        {
            _classRepo = classRepo;
            _childRepo = childRepository;
            _childrenClassRepo = childrenClassRepository;
            _mapper = mapper;
        }

        public async Task<AppActionResult> CreateChildClassAsync(ChildrenClassCreateDto childrenClassCreateDto)
        {
            var actionResult = new AppActionResult();
            // check class existing
            var classExisting = await _classRepo.Entities().Include(c => c.ClassTimes).SingleOrDefaultAsync(c => c.Id == childrenClassCreateDto.ClassId);
            if (classExisting == null)
            {
                return actionResult.BuildError("Not found class");
            }
            var listClassTime = classExisting.ClassTimes.ToList();

            // check child existing
            var child = await _childRepo.Entities().SingleOrDefaultAsync(c => c.Id == childrenClassCreateDto.ChildrenId);
            if (child == null)
            {
                return actionResult.BuildError("Not found children");
            }

            // get list children class by children id, include Class
            var listClassJoined = await _childrenClassRepo.Entities().Include(c => c.Class).Include(c => c.Class.ClassTimes).Where(c => c.ChildrenId == childrenClassCreateDto.ChildrenId).ToListAsync();
            bool isValidClassTime = true;
            // loop all children class joined
            foreach (var c in listClassJoined)
            {
                // loop each classTime of class joined
                foreach (var lt in c.Class.ClassTimes)
                {
                    // loop all classTime of class children want to join
                    foreach (var lct in listClassTime)
                    {
                        // compare classTime of class joined and want to join
                        if (lct.DayInWeek == lt.DayInWeek && lct.StarTime == lt.StarTime)
                        {
                            // if classTime is duplicate isValidClassTime will be false ann break loop;
                            isValidClassTime = false;
                            break;
                        }
                    }
                }
            }
            if (!isValidClassTime)
            {
                return actionResult.BuildError("Not valid class time!");
            }
            //add children class
            try
            {
                var childrenClass = _mapper.Map<ChildrenClass>(childrenClassCreateDto);
                await _childrenClassRepo.AddAsync(childrenClass);
                await _childrenClassRepo.SaveChangesAsync();
                return actionResult.BuildResult("Add success");
            }
            catch
            {
                return actionResult.BuildError("Add fail");
            }
        }

        public async Task<AppActionResult> GetChildrenClassByChildrenIDAsync(int childrenId)
        {
            var actionResult = new AppActionResult();

            if (childrenId <= 0)
            {
                return actionResult.BuildError("Invalid children ID.");
            }

            try
            {
                var childrenClass = await _childrenClassRepo.GetChildrenClassByChildrenIDAsync(childrenId);
                if (childrenClass == null || !childrenClass.Any())
                {
                    return actionResult.BuildError("No feedback found for the given children ID.");
                }
                return actionResult.BuildResult(childrenClass);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }

        public async Task<AppActionResult> GetChildrenClassByClassIDAsync(int classId)
        {
            var actionResult = new AppActionResult();

            if (classId <= 0)
            {
                return actionResult.BuildError("Invalid class ID.");
            }

            try
            {
                var childrenClass = await _childrenClassRepo.GetChildrenClassByClassIDAsync(classId);
                if (!childrenClass.Any())
                {
                    return actionResult.BuildError("No feedback found for the given class ID.");
                }
                return actionResult.BuildResult(childrenClass);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }

        public async Task<AppActionResult> GetChildrenClassByClassNameAsync(string className)
        {
            var actionResult = new AppActionResult();

            if (string.IsNullOrWhiteSpace(className))
            {
                return actionResult.BuildError("Class name must not be empty.");
            }

            try
            {
                var childrenClass = await _childrenClassRepo.GetChildrenClassByClassNameAsync(className);
                if (!childrenClass.Any())
                {
                    return actionResult.BuildError("No feedback found for the given class name.");
                }
                return actionResult.BuildResult(childrenClass);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }

        public async Task<AppActionResult> GetChildrensClassByChildrenNameAsync(string childrenName)
        {
            var actionResult = new AppActionResult();

            if (string.IsNullOrWhiteSpace(childrenName))
            {
                return actionResult.BuildError("Children name must not be empty.");
            }

            try
            {
                var childrenClass = await _childrenClassRepo.GetChildrensClassByChildrenNameAsync(childrenName);
                if (childrenClass == null || !childrenClass.Any())
                {
                    return actionResult.BuildError("No feedback found for the given children name.");
                }
                return actionResult.BuildResult(childrenClass);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }
    }
}
