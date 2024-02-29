using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class AcademicTranscript
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int CourseId { get; set; }
        public int ChildrenId { get; set; }
        public decimal Quiz1 { get; set; }
        public decimal Quiz2 { get; set; }
        public decimal Midterm { get; set; }
        public decimal Final { get; set; }
        public decimal Average { get; set; }
        public int Status { get; set; }

        public virtual Child Children { get; set; }
        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
