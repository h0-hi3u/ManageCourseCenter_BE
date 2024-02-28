using MCC.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface
{
    public interface IFeedbackService
    {
        Task<AppActionResult> GetFeedbackByChildrenIDAsync(int childrenId);
        Task<AppActionResult> GetFeedbackByChildrenNameAsync(string childrenName);
        Task<AppActionResult> GetFeedbackByClassIDAsync(int classId);
        Task<AppActionResult> GetFeedbackByClassNameAsync(string className);
        Task<AppActionResult> GetFeedbackByCourseIDAsync(int courseId);
        Task<AppActionResult> GetFeedbackByCourseNameAsync(string courseName);
    }
}
