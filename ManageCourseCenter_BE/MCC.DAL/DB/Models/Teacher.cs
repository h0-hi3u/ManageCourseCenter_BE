using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Teacher
    {
        public Teacher()
        {
            AcademicTranscripts = new HashSet<AcademicTranscript>();
            Classes = new HashSet<Class>();
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Phone { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }

        public virtual ICollection<AcademicTranscript> AcademicTranscripts { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
