using MCC.DAL.DB.Context;
using MCC.DAL.DB.Models;
using MCC.DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Repository.Implements;

public class ChildrenClassRepository : RepositoryGeneric<ChildrenClass>, IChildrendClassRepository
{
    public ChildrenClassRepository(ManageCourseCenterContext context) : base(context)
    {
    }
}
