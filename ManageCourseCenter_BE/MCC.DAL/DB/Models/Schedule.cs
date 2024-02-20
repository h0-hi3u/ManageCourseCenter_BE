using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Schedule
    {
        public int Id { get; set; }
        public int TeacherId { get; set; }
        public int ChildrenId { get; set; }
        public int ClassId { get; set; }
        public int RoomId { get; set; }
        public DateTime Date { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Attendance { get; set; }

        public virtual Child Children { get; set; }
        public virtual Class Class { get; set; }
        public virtual Room Room { get; set; }
        public virtual Teacher Teacher { get; set; }
    }
}
