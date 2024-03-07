using MCC.DAL.Common;
using MCC.DAL.Dto.AcademicTranscriptDto;
using MCC.DAL.Dto.CartDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface
{
    public interface ICartService
    {
        Task<AppActionResult> CreateCartAsync(CartCreateDto cartCreateDto);
    }
}
