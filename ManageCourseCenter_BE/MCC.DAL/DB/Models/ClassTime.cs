using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class ClassTime
    {
        public int Id { get; set; }
        public int ClassId { get; set; }
        public string DayInWeek { get; set; }
        public string StarTime { get; set; }
        public string EndTime { get; set; }

        public virtual Class Class { get; set; }
    }
}
