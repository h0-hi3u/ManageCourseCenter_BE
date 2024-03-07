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
        private IMapper _mapper;

        public CartService(ICartRepository cartRepo, IMapper mapper)
        {
            _cartRepo = cartRepo;
            _mapper = mapper;

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
    }
}
