using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class CartItemRepository : RepositoryGeneric<CartItem>, ICartItemRepository
{
    public CartItemRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<IEnumerable<CartItem>> getCartItemByParentIDAsync(int parentId)
    {
        var cartItems = await _dbSet
                .Include(a => a.Cart)
                .Where(t => t.Cart.ParentId == parentId)
                .ToListAsync();

        return cartItems;
    }
}
