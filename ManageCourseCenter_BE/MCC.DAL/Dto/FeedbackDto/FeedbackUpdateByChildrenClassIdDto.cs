using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.FeedbackDto
{
    public class FeedbackUpdateByChildrenClassIdDto
    {
        public int ChildrenClassId { get; set; }
        public int CourseRating { get; set; }
        public int TeacherRating { get; set; }
        public int EquipmentRating { get; set; }
        public string Description { get; set; }
    }
}
