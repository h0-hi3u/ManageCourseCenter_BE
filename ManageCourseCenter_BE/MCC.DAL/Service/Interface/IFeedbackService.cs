using MCC.DAL.Common;
using MCC.DAL.Dto.FeedbackDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface;

public interface IFeedbackService
{
    Task<AppActionResult> GetFeedbackByChildrenIDAsync(int childrenId);
    Task<AppActionResult> GetFeedbackByChildrenNameAsync(string childrenName);
    Task<AppActionResult> GetFeedbackByClassIDAsync(int classId);
    Task<AppActionResult> GetFeedbackByClassNameAsync(string className);
    Task<AppActionResult> GetFeedbackByCourseIDAsync(int courseId);
    Task<AppActionResult> GetFeedbackByCourseNameAsync(string courseName);
    Task<AppActionResult> CreateFeedbackAsync(FeedbackCreateDto feedbackCreateDto);
    Task<AppActionResult> UpdateFeedbackAsync(FeedbackUpdateDto feedbackUpdateDto);
    Task<AppActionResult> GetFeedbackByTeacherIdAsync(int teacherId, int pageSize, int pageIndex);
    Task<AppActionResult> GetAllFeedbackByParentIdAsync(int parentId, int pageSize, int pageIndex);
    Task<AppActionResult> UpdateFeedbackByChildrenClassId(FeedbackUpdateByChildrenClassIdDto feedbackUpdateDto);
    Task<AppActionResult> CreateFeedbackByChildrenClassId(int childrenclassId, FeedbackCreateDto feedbackCreateDto);
}
