using AutoMapper;
using MCC.DAL.Common;
using MCC.DAL.Constants;
using MCC.DAL.DB.Models;
using MCC.DAL.Dto.CartItemDto;
using MCC.DAL.Dto.EquipmentDto;
using MCC.DAL.Dto.RoomDto;
using MCC.DAL.Repository.Implements;
using MCC.DAL.Repository.Interface;
using MCC.DAL.Repository.Interfacep;
using MCC.DAL.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MCC.DAL.Service.Implements.EquipmentReportService;

namespace MCC.DAL.Service.Implements
{
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;
        private readonly ICourseRepository _courseRepository;
        private readonly IClassReposotory _classReposotory;
        private readonly IChildRepository _childRepository;
        private readonly ICartRepository _cartRepository;
        private readonly IMapper _mapper;

        public CartItemService(ICartItemRepository cartItemRepository, IMapper mapper, ICourseRepository courseRepository, IClassReposotory classReposotory, IChildRepository childRepository, ICartRepository cartRepository)
        {
            _cartItemRepository = cartItemRepository;
            _courseRepository = courseRepository;
            _classReposotory = classReposotory;
            _childRepository = childRepository;
            _cartRepository = cartRepository;
            _mapper = mapper;
        }
        public async Task<AppActionResult> getCartItemByParentIDAsync(int parentId)
        {
            var actionResult = new AppActionResult();
            var data = await _cartItemRepository.getCartItemByParentIDAsync(parentId);
            if (data.Any())
            {
                return actionResult.BuildResult(data);
            }
            else
            {
                return actionResult.BuildError("Not found");
            }
        }

        public async Task<AppActionResult> UpdateCartItemAsync(int cartItemId, UpdateCartItemDto updateCartItemDto)
        {
            var actionResult = new AppActionResult();


            var cartItem = await _cartItemRepository.GetByIdAsync(cartItemId);
            if (cartItem == null)
            {
                return actionResult.BuildError("CartItem not found.");
            }

            var course = await _courseRepository.GetByIdAsync(updateCartItemDto.CourseId);
            if (course == null)
            {
                return actionResult.BuildError("Course not found.");
            }

            var cart = await _cartRepository.GetByIdAsync(updateCartItemDto.CartId);
            if (course == null)
            {
                return actionResult.BuildError("Course not cart.");
            }

            var classItem = await _classReposotory.GetByIdAsync(updateCartItemDto.ClassId);
            if (classItem == null)
            {
                return actionResult.BuildError("Class not found.");
            }

            // check class has course
            if (classItem.CourseId != updateCartItemDto.CourseId)
            {
                return actionResult.BuildError("Class does not belong to the specified Course.");
            }

            var child = await _childRepository.GetByIdAsync(updateCartItemDto.ChildrenId);
            if (child == null)
            {
                return actionResult.BuildError("Child not found.");
            }
            try
            {
                _mapper.Map(updateCartItemDto, cartItem);

                await _cartItemRepository.UpdateCartItemAsync(cartItem);
                return actionResult.BuildResult("Update success");
            }
            catch (Exception ex)
            {
                return actionResult.BuildError($"Update fail: {ex.Message}");
            }
        }

    }
}