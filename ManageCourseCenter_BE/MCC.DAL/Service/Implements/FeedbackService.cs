﻿using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Implements
{
    public class FeedbackService : IFeedbackService
    {
        private readonly IFeedbackRepository _feedbackRepo;

        public FeedbackService(IFeedbackRepository feedbackRepo)
        {
            _feedbackRepo = feedbackRepo;
        }

        public async Task<AppActionResult> GetFeedbackByChildrenIDAsync(int childrenId)
        {
            var actionResult = new AppActionResult();

            if (childrenId <= 0)
            {
                return actionResult.BuildError("Invalid children ID.");
            }

            try
            {
                var feedbacks = await _feedbackRepo.GetFeedbackByChildrenIDAsync(childrenId);
                if (feedbacks == null || !feedbacks.Any())
                {
                    return actionResult.BuildError("No feedback found for the given children ID.");
                }
                return actionResult.BuildResult(feedbacks);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }

        public async Task<AppActionResult> GetFeedbackByChildrenNameAsync(string childrenName)
        {
            var actionResult = new AppActionResult();

            if (string.IsNullOrWhiteSpace(childrenName))
            {
                return actionResult.BuildError("Children name must not be empty.");
            }

            try
            {
                var feedbacks = await _feedbackRepo.GetFeedbackByChildrenNameAsync(childrenName);
                if (feedbacks == null || !feedbacks.Any())
                {
                    return actionResult.BuildError("No feedback found for the given children name.");
                }
                return actionResult.BuildResult(feedbacks);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }

        public async Task<AppActionResult> GetFeedbackByClassIDAsync(int classId)
        {
            var actionResult = new AppActionResult();

            if (classId <= 0)
            {
                return actionResult.BuildError("Invalid class ID.");
            }

            try
            {
                var feedbacks = await _feedbackRepo.GetFeedbackByClassIDAsync(classId);
                if (!feedbacks.Any())
                {
                    return actionResult.BuildError("No feedback found for the given class ID.");
                }
                return actionResult.BuildResult(feedbacks);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }

        public async Task<AppActionResult> GetFeedbackByClassNameAsync(string className)
        {
            var actionResult = new AppActionResult();

            if (string.IsNullOrWhiteSpace(className))
            {
                return actionResult.BuildError("Class name must not be empty.");
            }

            try
            {
                var feedbacks = await _feedbackRepo.GetFeedbackByClassNameAsync(className);
                if (!feedbacks.Any())
                {
                    return actionResult.BuildError("No feedback found for the given class name.");
                }
                return actionResult.BuildResult(feedbacks);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }

        public async Task<AppActionResult> GetFeedbackByCourseIDAsync(int courseId)
        {
            var actionResult = new AppActionResult();

            if (courseId <= 0)
            {
                return actionResult.BuildError("Invalid course ID.");
            }

            try
            {
                var feedbacks = await _feedbackRepo.GetFeedbackByCourseIDAsync(courseId);
                if (!feedbacks.Any())
                {
                    return actionResult.BuildError("No feedback found for the given course ID.");
                }
                return actionResult.BuildResult(feedbacks);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }

        public async Task<AppActionResult> GetFeedbackByCourseNameAsync(string courseName)
        {
            var actionResult = new AppActionResult();

            if (string.IsNullOrWhiteSpace(courseName))
            {
                return actionResult.BuildError("Course name must not be empty.");
            }

            try
            {
                var feedbacks = await _feedbackRepo.GetFeedbackByCourseNameAsync(courseName);
                if (!feedbacks.Any())
                {
                    return actionResult.BuildError("No feedback found for the given course name.");
                }
                return actionResult.BuildResult(feedbacks);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }
    }
}