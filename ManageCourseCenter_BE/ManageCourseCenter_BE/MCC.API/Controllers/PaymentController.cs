using MCC.DAL.Dto.CartDto;
using MCC.DAL.Dto.PaymentDto;
using MCC.DAL.Service.Implements;
using MCC.DAL.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace MCC.API.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet("get-payment_by_parent_id")]
        public async Task<IActionResult> GetPaymentByParentIDAsync(int parentId)
        {
            var result = await _paymentService.getPaymentByParentIDAsync(parentId);
            return Ok(result);
        }

        [HttpGet("get-payment_by_parent_email")]
        public async Task<IActionResult> GetPaymentByParentEmailAsync(string parentEmail)
        {
            var result = await _paymentService.getPaymentByParentEmailAsync(parentEmail);
            return Ok(result);
        }

        [HttpPut("update-payment-status")]
        public async Task<IActionResult> UpdatePaymentStatusAsync(UpdatePaymentStatusDto updatePaymentStatusDto)
        {
            var result = await _paymentService.UpdatePaymentStatusAsync(updatePaymentStatusDto);

            return Ok(result);
        }
    }
}