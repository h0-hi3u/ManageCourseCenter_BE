using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class CartItem
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int CourseId { get; set; }
        public int ClassId { get; set; }
        public int ChildrenId { get; set; }

        public virtual Cart Cart { get; set; }
        public virtual Child Children { get; set; }
        public virtual Class Class { get; set; }
        public virtual Course Course { get; set; }
    }
}
