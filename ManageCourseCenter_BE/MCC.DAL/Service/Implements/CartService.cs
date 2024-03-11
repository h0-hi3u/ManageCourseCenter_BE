using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.AcademicTranscriptDto;
using MCC.DAL.Dto.CartDto;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Implements
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepo;
        private readonly IMapper _mapper;
        private readonly IParentRepository _parentRepository;

        public CartService(ICartRepository cartRepo, IMapper mapper, IParentRepository parentRepository)
        {
            _cartRepo = cartRepo;
            _mapper = mapper;
            _parentRepository = parentRepository;
        }
        public async Task<AppActionResult> CreateCartAsync(CartCreateDto cartCreateDto)
        {
            var actionResult = new AppActionResult();

            try
            {
                var cart = _mapper.Map<Cart>(cartCreateDto);
                await _cartRepo.AddAsync(cart);
                await _cartRepo.SaveChangesAsync();
                return actionResult.SetInfo(true, "Add success");
            }
            catch
            {
                return actionResult.BuildError("Add fail");
            }
        }

        public enum CartStatus
        {
            STORING = 1,
            PAID = 2
        }

        public async Task<AppActionResult> UpdateStatusCartAsync(UpdateStatusCartDto updateStatusCartDto)
        {
            var actionResult = new AppActionResult();

            try
            {
                var cart = await _cartRepo.GetByIdAsync(updateStatusCartDto.Id);
                if (cart == null)
                {
                    return actionResult.BuildError("Cart not found");
                }

                if (!Enum.IsDefined(typeof(CartStatus), updateStatusCartDto.Status))
                {
                    return actionResult.BuildError("Invalid cart status");
                }

                cart.Status = (int)(CartStatus)updateStatusCartDto.Status;
                await _cartRepo.SaveChangesAsync();

                return actionResult.SetInfo(true, "Update success");
            }
            catch
            {
                return actionResult.BuildError("Update fail");
            }
        }

    }
}
