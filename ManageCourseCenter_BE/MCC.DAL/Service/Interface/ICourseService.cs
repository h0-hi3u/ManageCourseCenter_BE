using MCC.DAL.Common;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.TeacherDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface;

public interface ICourseService
{
    Task<AppActionResult> GetAllCoureAsync();
    Task<AppActionResult> GetCourseByNameAsync(string name);
    Task<AppActionResult> GetCourseByIdAsync(int id);
    Task<AppActionResult> CreateCourseAsync(CourseCreateDto courseCreateDto);
    Task<AppActionResult> UpdateCourseAsync(int courseId, CourseUpdateDto courseUpdateDto);
    Task<AppActionResult> SearchCourseByNameAsync(string name);
    Task<AppActionResult> CountNumberCourse();
}
