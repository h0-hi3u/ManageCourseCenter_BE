using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCC.DAL.Common;
using MCC.DAL.Dto.EquipmentDto;

namespace MCC.DAL.Service.Interface
{
    public interface IEquipmentReportService
    {
        Task<AppActionResult> GetAllEquipmentReportAsync();
        Task<AppActionResult> GetEquipmentReportByIdAsync(int id);
        Task<AppActionResult> GetEquipmentReportByEquipmentIdAsync(int equipmentid);
        Task<AppActionResult> GetEquipmentReportByRoomIdAsync(int roomid);
        Task<AppActionResult> GetEquipmentReportByRoomNoAsync(int roomno);
        Task<AppActionResult> GetEquipmentReportByEquipmentNameAsync(string equipmentname);
        Task<AppActionResult> CreateEquipmentReportAsync(EquipmentReportCreateDto equipmentReportCreateDto);
        Task<AppActionResult> GetReptortByTeacherIdAsync(int teacherId, int pageSize, int pageIndex);
        Task<AppActionResult> UpdateEquipmentReportAsync(int equipmentReportId, EquipmentReportUpdateDto equipmentReportUpdateDto);
        Task<AppActionResult> GetALlEquipmentReportPagingAsync(int pageSize, int pageIndex);
        Task<AppActionResult> SetEquipmentReportCloseByIdAsync(int reportId);
    }
}
