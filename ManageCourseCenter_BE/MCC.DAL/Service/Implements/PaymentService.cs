using MCC.DAL.Common;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Implements
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;

        public PaymentService(IPaymentRepository paymentRepository)
        {
            _paymentRepository = paymentRepository;
        }
        public async Task<AppActionResult> getPaymentByParentEmailAsync(string parentEmail)
        {
            var actionResult = new AppActionResult();
            var data = await _paymentRepository.getPaymentByParentEmailAsync(parentEmail);
            if (data.Any())
            {
                return actionResult.BuildResult(data);
            }
            else
            {
                return actionResult.BuildError("Not found");
            }
        }

        public async Task<AppActionResult> getPaymentByParentIDAsync(int parentId)
        {
            var actionResult = new AppActionResult();
            var data = await _paymentRepository.getPaymentByParentIDAsync(parentId);
            if (data.Any())
            {
                return actionResult.BuildResult(data);
            }
            else
            {
                return actionResult.BuildError("Not found");
            }
        }
    }
}