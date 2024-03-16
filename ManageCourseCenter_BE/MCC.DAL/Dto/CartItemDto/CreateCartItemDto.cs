using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.CartItemDto
{
    public class CreateCartItemDto
    {
        public int CartId { get; set; }
        public int CourseId { get; set; }
        public int ClassId { get; set; }
        public int ChildrenId { get; set; }
    }
}
