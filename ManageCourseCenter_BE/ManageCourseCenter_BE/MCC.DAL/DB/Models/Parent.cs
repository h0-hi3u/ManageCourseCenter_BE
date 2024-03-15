using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Parent
    {
        public Parent()
        {
            Carts = new HashSet<Cart>();
            Children = new HashSet<Child>();
        }

        public int Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string? ImgUrl { get; set; }
        public string Phone { get; set; }
        public DateTime BirthDay { get; set; }
        public int Gender { get; set; }
        public int Role { get; set; }
        public int Status { get; set; }

        public virtual ICollection<Cart> Carts { get; set; }
        public virtual ICollection<Child> Children { get; set; }
    }
}
