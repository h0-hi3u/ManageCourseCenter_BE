using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IAcademicTranscriptRepository : IRepositoryGeneric<AcademicTranscript>
{
    Task<IEnumerable<AcademicTranscript>> getTranscriptByTeacherIDAsync(int teacherId);
    Task<IEnumerable<AcademicTranscript>> getTranscriptByTeacherNameAsync(string teacherName);
    Task<IEnumerable<AcademicTranscript>> getTranscriptByChildrenIDAsync(int childrenId);
    Task<IEnumerable<AcademicTranscript>> getTranscriptByChildrenNameAsync(string childrenName);
    Task<IEnumerable<AcademicTranscript>> getTranscriptByChildrenNameAndCourseNameAsync(string childrenName, string courseName);
    Task<bool> UpdateAcademicTranscriptAsync(AcademicTranscript academicTranscript);
}
