using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto;

public class PagingDto
{
    public object? Data { get; set; }
    public int TotalRecords { get; set; }
}
