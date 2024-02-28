using AutoMapper;
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
            try
            {
                var feedbacks = await _feedbackRepo.GetFeedbackByChildrenIDAsync(childrenId);
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
            try
            {
                var feedbacks = await _feedbackRepo.GetFeedbackByClassNameAsync(childrenName);
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
            try
            {
                var feedbacks = await _feedbackRepo.GetFeedbackByClassIDAsync(classId);
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
            try
            {
                var feedbacks = await _feedbackRepo.GetFeedbackByClassNameAsync(className);
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
            try
            {
                var feedbacks = await _feedbackRepo.GetFeedbackByCourseIDAsync(courseId);
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
            try
            {
                var feedbacks = await _feedbackRepo.GetFeedbackByCourseNameAsync(courseName);
                return actionResult.BuildResult(feedbacks);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }
    }
}
