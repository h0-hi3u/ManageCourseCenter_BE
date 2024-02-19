using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int ChildrenId { get; set; }
        public int CourseId { get; set; }
        public int CourseRating { get; set; }
        public int TeacherRating { get; set; }
        public int EquipmentRating { get; set; }
        public string Description { get; set; }

        public virtual Child Children { get; set; }
        public virtual Course Course { get; set; }
    }
}
