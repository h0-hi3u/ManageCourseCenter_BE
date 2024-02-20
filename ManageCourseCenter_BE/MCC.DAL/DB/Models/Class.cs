using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Class
    {
        public Class()
        {
            CartItems = new HashSet<CartItem>();
            ClassTimes = new HashSet<ClassTime>();
            Schedules = new HashSet<Schedule>();
        }

        public int Id { get; set; }
        public int CourseId { get; set; }
        public int TeacherId { get; set; }
        public int TimeId { get; set; }
        public string Name { get; set; }
        public int Status { get; set; }

        public virtual Course Course { get; set; }
        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<ClassTime> ClassTimes { get; set; }
        public virtual ICollection<Schedule> Schedules { get; set; }
    }
}
