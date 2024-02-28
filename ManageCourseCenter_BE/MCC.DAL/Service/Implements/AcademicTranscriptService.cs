﻿using MCC.DAL.Common;
using MCC.DAL.Repository.Implements;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Implements
{
    public class AcademicTranscriptService : IAcademicTranscriptService
    {
        private readonly IAcademicTranscriptRepository _academicTranscriptRepo;

        public AcademicTranscriptService(IAcademicTranscriptRepository academicTranscriptRepo)
        {
            _academicTranscriptRepo = academicTranscriptRepo;
        }

        public async Task<AppActionResult> getTranscriptByChildrenIDAsync(int childrenId)
        {
            var actionResult = new AppActionResult();

            if (childrenId <= 0)
            {
                return actionResult.BuildError("Invalid children ID.");
            }

            try
            {
                var transcript = await _academicTranscriptRepo.getTranscriptByChildrenIDAsync(childrenId);
                if (transcript == null || !transcript.Any())
                {
                    return actionResult.BuildError("No feedback found for the given children ID.");
                }
                return actionResult.BuildResult(transcript);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }

        public async Task<AppActionResult> getTranscriptByChildrenNameAndCourseNameAsync(string childrenName, string courseName)
        {
            var actionResult = new AppActionResult();

            if (string.IsNullOrWhiteSpace(childrenName) || string.IsNullOrWhiteSpace(courseName))
            {
                return actionResult.BuildError("Children name and course name must not be empty.");
            }

            try
            {
                var transcript = await _academicTranscriptRepo.getTranscriptByChildrenNameAndCourseNameAsync(childrenName, courseName);
                if (transcript == null || !transcript.Any())
                {
                    return actionResult.BuildError("No transcript found for the given children name and course name.");
                }
                return actionResult.BuildResult(transcript);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }

        public async Task<AppActionResult> getTranscriptByChildrenNameAsync(string childrenName)
        {
            var actionResult = new AppActionResult();

            if (string.IsNullOrWhiteSpace(childrenName))
            {
                return actionResult.BuildError("Children name must not be empty.");
            }

            try
            {
                var transcript = await _academicTranscriptRepo.getTranscriptByChildrenNameAsync(childrenName);
                if (transcript == null || !transcript.Any())
                {
                    return actionResult.BuildError("No feedback found for the given children name.");
                }
                return actionResult.BuildResult(transcript);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }

        public async Task<AppActionResult> getTranscriptByTeacherIDAsync(int teacherId)
        {
            var actionResult = new AppActionResult();

            if (teacherId <= 0)
            {
                return actionResult.BuildError("Invalid teacher ID.");
            }

            try
            {
                var transcript = await _academicTranscriptRepo.getTranscriptByTeacherIDAsync(teacherId);
                if (transcript == null || !transcript.Any())
                {
                    return actionResult.BuildError("No transcript found for the given teacher ID.");
                }
                return actionResult.BuildResult(transcript);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }

        public async Task<AppActionResult> getTranscriptByTeacherNameAsync(string teacherName)
        {
            var actionResult = new AppActionResult();

            if (string.IsNullOrWhiteSpace(teacherName))
            {
                return actionResult.BuildError("Teacher name must not be empty.");
            }

            try
            {
                var transcript = await _academicTranscriptRepo.getTranscriptByTeacherNameAsync(teacherName);
                if (transcript == null || !transcript.Any())
                {
                    return actionResult.BuildError("No transcript found for the given teacher name.");
                }
                return actionResult.BuildResult(transcript);
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"An error occurred: {ex.Message}");
            }
        }
    }
}