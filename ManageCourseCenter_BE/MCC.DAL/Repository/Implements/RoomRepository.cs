using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;

namespace MCC.DAL.Repository.Implements;

public class RoomRepository : RepositoryGeneric<Room>, IRoomRepository
{
    public RoomRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
