using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class CartRepository : RepositoryGeneric<Cart>, ICartRepository
{
    public CartRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
