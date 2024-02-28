﻿using MCC.DAL.Common;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Implements
{
    public class ChildrenClassService : IChildrenClassService
    {
        private readonly IChildrendClassRepository _childrendClassRepo;

        public ChildrenClassService(IChildrendClassRepository childrendClassRepo)
        {
            _childrendClassRepo = childrendClassRepo;
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
                var childrenClass = await _childrendClassRepo.GetChildrenClassByChildrenIDAsync(childrenId);
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
                var childrenClass = await _childrendClassRepo.GetChildrenClassByClassIDAsync(classId);
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
                var childrenClass = await _childrendClassRepo.GetChildrenClassByClassNameAsync(className);
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
                var childrenClass = await _childrendClassRepo.GetChildrensClassByChildrenNameAsync(childrenName);
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