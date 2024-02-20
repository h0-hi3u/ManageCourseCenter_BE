using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class PaymentRepository : RepositoryGeneric<Payment>, IPaymentRepository
{
    public PaymentRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
