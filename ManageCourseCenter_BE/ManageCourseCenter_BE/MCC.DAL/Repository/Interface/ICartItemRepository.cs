using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface ICartItemRepository : IRepositoryGeneric<CartItem>
{
    Task<IEnumerable<CartItem>> getCartItemByParentIDAsync(int parentId);
    Task<bool> UpdateCartItemAsync(CartItem cartItem);
    Task<bool> DeleteCartItemAsync(int cartItemId);
}
