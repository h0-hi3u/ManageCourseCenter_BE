using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Course
    {
        public Course()
        {
            AcademicTranscripts = new HashSet<AcademicTranscript>();
            CartItems = new HashSet<CartItem>();
            Classes = new HashSet<Class>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime OpenFormTime { get; set; }
        public DateTime CloseFormTime { get; set; }
        public double? Price { get; set; }
        public int Level { get; set; }
        public int TotalSlot { get; set; }
        public int Status { get; set; }

        public virtual ICollection<AcademicTranscript> AcademicTranscripts { get; set; }
        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Class> Classes { get; set; }
    }
}
