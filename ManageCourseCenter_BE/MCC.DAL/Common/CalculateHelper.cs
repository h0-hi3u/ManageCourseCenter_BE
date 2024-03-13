using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Common;

public static class CalculateHelper
{
    public static int CalculatePaging(int pageSize, int pageIndex)
    {
        pageSize = pageSize < 1 ? 1 : pageSize;
        pageIndex = pageIndex < 1 ? 1 : pageIndex;
        return (pageIndex - 1) * pageSize;
    }
}
