using MCC.DAL.Common;
using MCC.DAL.Dto.CartDto;
using MCC.DAL.Dto.PaymentDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface
{
    public interface IPaymentService
    {
        public Task<AppActionResult> getPaymentByParentIDAsync(int parentId);
        public Task<AppActionResult> getPaymentByParentEmailAsync(string parentEmail);
        Task<AppActionResult> UpdatePaymentStatusAsync(UpdatePaymentStatusDto updatePaymentStatusDto);
        Task<AppActionResult> UpdatePaymentProcessTimeAndStatusAsync(int paymentId, UpdatePaymentProcessTimeAndStatusDto updatePaymentProcessTimeAndStatusDto);
        Task<AppActionResult> CreatePaymentAsync(CreatePaymentDto createPaymentDto);
    }
}