using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MCC.DAL.Common;

namespace MCC.DAL.Service.Interface
{
    public interface IEquipmentReportService
    {
        Task<AppActionResult> GetAllEquipmentReportAsync();
    }
}
