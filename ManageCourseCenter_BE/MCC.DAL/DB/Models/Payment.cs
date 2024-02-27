using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Payment
    {
        public int Id { get; set; }
        public int CartId { get; set; }
        public int Method { get; set; }
        public int Status { get; set; }

        public virtual Cart Cart { get; set; }
    }
}
