using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.Constants;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.CourceDto;
using MCC.DAL.Dto.PaymentDto;
using MCC.DAL.Repository.Implements;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using Microsoft.EntityFrameworkCore;
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
        private readonly ICartRepository _cartRepository;

        public PaymentService(IPaymentRepository paymentRepository, IMapper mapper, ICartRepository cartRepository)
        {
            _paymentRepository = paymentRepository;
            _mapper = mapper;
            _cartRepository = cartRepository;
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

        public async Task<AppActionResult> CreatePaymentAsync(CreatePaymentDto createPaymentDto)
        {
            var actionResult = new AppActionResult();

            var cart = await _cartRepository.GetByIdAsync(createPaymentDto.CartId);
            if (cart == null)
            {
                return actionResult.BuildError("Cart not found.");
            }

            var existPayment = await _paymentRepository.Entities().SingleOrDefaultAsync(c => c.CartId == createPaymentDto.CartId);
            if (existPayment != null)
            {
                return actionResult.BuildError("Payment has exist with this cart! Cannot create payment.");
            }

            if (!Enum.IsDefined(typeof(PaymentStatus), createPaymentDto.Status))
            {
                return actionResult.BuildError("Invalid payment status");
            }

            try
            {
                var payment = new Payment
                {
                    CartId = createPaymentDto.CartId,
                    Method = CoreConstants.STT_Payment_Method_Banking,
                    ProcessTime = DateTime.Now,
                    Status = (int)(PaymentStatus)createPaymentDto.Status
                };

                _ = _paymentRepository.AddAsync(payment);
                await _paymentRepository.SaveChangesAsync();
                return actionResult.BuildResult("Create success");
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"Create fail: {ex.Message}");
            }
        }

        public async Task<AppActionResult> UpdatePaymentProcessTimeAndStatusAsync(int Id, UpdatePaymentProcessTimeAndStatusDto updatePaymentProcessTimeAndStatusDto)
        {
            var actionResult = new AppActionResult();


            var payment = await _paymentRepository.GetByIdAsync(Id);
            if (payment == null)
            {
                return actionResult.BuildError("Payment not found");
            }

            if (!Enum.IsDefined(typeof(PaymentStatus), updatePaymentProcessTimeAndStatusDto.Status))
            {
                return actionResult.BuildError("Invalid payment status");
            }
            try
            {
                _mapper.Map(updatePaymentProcessTimeAndStatusDto, payment);
                payment.Status = (int)(PaymentStatus)updatePaymentProcessTimeAndStatusDto.Status;
                payment.ProcessTime = DateTime.Now;
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