using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.AcademicTranscriptDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface
{
    public interface IAcademicTranscriptService
    {
        Task<AppActionResult> getTranscriptByTeacherIDAsync(int teacherId);
        Task<AppActionResult> getTranscriptByTeacherNameAsync(string teacherName);
        Task<AppActionResult> getTranscriptByChildrenIDAsync(int childrenId);
        Task<AppActionResult> getTranscriptByChildrenNameAsync(string childrenName);
        Task<AppActionResult> getTranscriptByChildrenNameAndCourseNameAsync(string childrenName, string courseName);
        Task<AppActionResult> UpdateAcademicTranscriptAsync(int transcriptId, AcademicTranscriptUpdateDto academicUpdateDto);
        Task<AppActionResult> CreateAcademicTranscriptAsync(AcademicTranscriptCreateDto academicTranscriptCreateDto);
        Task<AppActionResult> GetAcademicTranscriptByIdAsync(int academicTranscriptId);
        Task<AppActionResult> GetTransByClassId(int classId);
    }
}
