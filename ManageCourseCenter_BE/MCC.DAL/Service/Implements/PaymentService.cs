using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.PaymentDto;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MCC.DAL.Service.Implements.CartService;

namespace MCC.DAL.Service.Implements
{
    public class PaymentService : IPaymentService
    {
        private readonly IPaymentRepository _paymentRepository;
        private readonly IMapper _mapper;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
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

        public enum PaymentStatus
        {
            PROCESSING = 1,
            SUCCESS = 2,
            FAIL = 3
        }

        public async Task<AppActionResult> UpdatePaymentStatusAsync(UpdatePaymentStatusDto updatePaymentStatusDto)
        {
            var actionResult = new AppActionResult();


            var payment = await _paymentRepository.GetByIdAsync(updatePaymentStatusDto.Id);
            if (payment == null)
            {
                return actionResult.BuildError("Payment not found");
            }

            if (!Enum.IsDefined(typeof(PaymentStatus), updatePaymentStatusDto.Status))
            {
                return actionResult.BuildError("Invalid payment status");
            }
            try
            {
                _mapper.Map(updatePaymentStatusDto, payment);
                payment.Status = (int)(PaymentStatus)updatePaymentStatusDto.Status;
                _paymentRepository.Update(payment);
                await _paymentRepository.SaveChangesAsync();

                return actionResult.SetInfo(true, "Update success");
            }
            catch
            {
                return actionResult.BuildError("Update fail");
            }
        }
    }
}