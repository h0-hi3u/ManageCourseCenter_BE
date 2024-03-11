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
    public class CartItemService : ICartItemService
    {
        private readonly ICartItemRepository _cartItemRepository;

        public CartItemService(ICartItemRepository cartItemRepository)
        {
            _cartItemRepository = cartItemRepository;
        }

        public async Task<AppActionResult> DeleteCartItemAsync(int cartItemId)
        {
            var result = new AppActionResult();
            var success = await _cartItemRepository.DeleteCartItemAsync(cartItemId);

            if (!success)
            {
                return result.BuildError("CartItem not found or failed to delete.");
            }

            return result.BuildResult("CartItem deleted successfully.");
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
    }
}