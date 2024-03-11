using MCC.DAL.Common;
using MCC.DAL.Dto.CartDto;
using MCC.DAL.Dto.CartItemDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Service.Interface
{
    public interface ICartItemService
    {
        public Task<AppActionResult> getCartItemByParentIDAsync(int parentId);
        Task<AppActionResult> DeleteCartItemAsync(int cartItemId);
        Task<AppActionResult> UpdateCartItemAsync(int cartItemId,UpdateCartItemDto updateCartItemDto);

    }
}
