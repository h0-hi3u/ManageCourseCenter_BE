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

    public async Task<bool> DeleteCartItemAsync(int cartItemId)
    {
        var cartItem = await _context.CartItems.FindAsync(cartItemId);
        if (cartItem == null)
        {
            return false;
        }

        _context.CartItems.Remove(cartItem);
        await _context.SaveChangesAsync();
        return true;
    }

    public async Task<IEnumerable<CartItem>> getCartItemByParentIDAsync(int parentId)
    {
        var cartItems = await _dbSet
                .Include(a => a.Cart)
                .Where(t => t.Cart.ParentId == parentId)
                .ToListAsync();

        return cartItems;
    }

    public async Task<bool> UpdateCartItemAsync(CartItem cartItem)
    {
        try
        {
            _dbSet.Update(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public async Task<bool> CreateCartItemAsync(CartItem cartItem)
    {
        try
        {
            _dbSet.Add(cartItem);
            await _context.SaveChangesAsync();
            return true;
        }
        catch
        {
            return false;
        }
    }
}
