using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Feedback
    {
        public int Id { get; set; }
        public int ChildrenClassId { get; set; }
        public int CourseRating { get; set; }
        public int TeacherRating { get; set; }
        public int EquipmentRating { get; set; }
        public string Description { get; set; }

        public virtual ChildrenClass ChildrenClass { get; set; }
    }
}
