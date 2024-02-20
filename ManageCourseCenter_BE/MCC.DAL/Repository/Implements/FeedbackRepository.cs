using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class FeedbackRepository : RepositoryGeneric<Feedback>, IFeedbackRepository
{
    public FeedbackRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
