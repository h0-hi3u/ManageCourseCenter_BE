using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace MCC.DAL.Repository.Implements;

public class PaymentRepository : RepositoryGeneric<Payment>, IPaymentRepository
{
    public PaymentRepository(ManageCourseCenterContext context) : base(context)
    {
    }

    public async Task<IEnumerable<Payment>> getPaymentByParentEmailAsync(string parentEmail)
    {
        var payments = await _dbSet
                .Include(a => a.Cart)
                .Where(t => t.Cart.Parent.Email == parentEmail)
                .ToListAsync();

        return payments;
    }

    public async Task<IEnumerable<Payment>> getPaymentByParentIDAsync(int parentId)
    {
        var payments = await _dbSet
                .Include(a => a.Cart)
                .Where(t => t.Cart.ParentId == parentId)
                .ToListAsync();

        return payments;
    }
}
