using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Parent
    {
        public Parent()
        {
            Children = new HashSet<Child>();
            Payments = new HashSet<Payment>();
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

        public virtual ICollection<Child> Children { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
