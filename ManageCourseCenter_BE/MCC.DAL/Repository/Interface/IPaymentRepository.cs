using MCC.DAL.DB.Models;

namespace MCC.DAL.Repository.Interface;

public interface IPaymentRepository : IRepositoryGeneric<Payment>
{
    Task<IEnumerable<Payment>> getPaymentByParentIDAsync(int parentId);
    Task<IEnumerable<Payment>> getPaymentByParentEmailAsync(string parentEmail);
}
