﻿using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers
{
    [Route("api/Controller")]
    [ApiController]
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        [HttpGet("get-by-childrenId")]
        public async Task<IActionResult> GetFeedbackByChildrenId(int childrenId)
        {
            var result = await _feedbackService.GetFeedbackByChildrenIDAsync(childrenId);
            return Ok(result);
        }

        [HttpGet("get-by-childrenName")]
        public async Task<IActionResult> GetFeedbackByChildrenName(string childrenName)
        {
            var result = await _feedbackService.GetFeedbackByChildrenNameAsync(childrenName);
            return Ok(result);
        }

        [HttpGet("get-by-classId")]
        public async Task<IActionResult> GetFeedbackByClassId(int classId)
        {
            var result = await _feedbackService.GetFeedbackByClassIDAsync(classId);
            return Ok(result);
        }

        [HttpGet("get-by-className")]
        public async Task<IActionResult> GetFeedbackByClassName(string className)
        {
            var result = await _feedbackService.GetFeedbackByClassNameAsync(className);
            return Ok(result);
        }

        [HttpGet("get-by-courseId")]
        public async Task<IActionResult> GetFeedbackByCourseId(int courseId)
        {
            var result = await _feedbackService.GetFeedbackByCourseIDAsync(courseId);
            return Ok(result);
        }

        [HttpGet("get-by-courseName")]
        public async Task<IActionResult> GetFeedbackByCourseName(string courseName)
        {
            var result = await _feedbackService.GetFeedbackByCourseNameAsync(courseName);
            return Ok(result);
        }
    }
}