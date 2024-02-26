using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Child
    {
        public Child()
        {
            AcademicTranscripts = new HashSet<AcademicTranscript>();
            CartItems = new HashSet<CartItem>();
            Feedbacks = new HashSet<Feedback>();
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public int ParentId { get; set; }
        public string FullName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }

        public virtual ICollection<AcademicTranscript> AcademicTranscripts { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
