using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IFeedbackRepository: IRepositoryGeneric<Feedback>
{
    Task<IEnumerable<Feedback>> GetFeedbackByChildrenIDAsync(int childrenId);
    Task<IEnumerable<Feedback>> GetFeedbackByChildrenNameAsync(string childrenName);
    Task<IEnumerable<Feedback>> GetFeedbackByClassIDAsync(int classId);
    Task<IEnumerable<Feedback>> GetFeedbackByClassNameAsync(string className);
    Task<IEnumerable<Feedback>> GetFeedbackByCourseIDAsync(int courseId);
    Task<IEnumerable<Feedback>> GetFeedbackByCourseNameAsync(string courseName);
    Task<IEnumerable<Feedback>> GetAllFeedbackByParentIdAsync(int parentId, int pageSize, int pageIndex);
}
