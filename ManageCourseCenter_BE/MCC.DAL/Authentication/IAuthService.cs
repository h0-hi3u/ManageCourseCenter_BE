using MCC.DAL.DB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Authentication
{
    public interface IAuthService
    {
        string GenerateJwtToken(Child child);
    }
}
