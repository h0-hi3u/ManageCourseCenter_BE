using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class CartItemRepository : RepositoryGeneric<CartItem>, ICartItemRepository
{
    public CartItemRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
