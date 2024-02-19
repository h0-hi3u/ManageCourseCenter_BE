using System;
using System.Collections.Generic;

namespace MCC.DAL.DB.Models
{
    public partial class Cart
    {
        public Cart()
        {
            CartItems = new HashSet<CartItem>();
            Payments = new HashSet<Payment>();
        }

        public int Id { get; set; }
        public int ParentId { get; set; }
        public int Status { get; set; }

        public virtual ICollection<CartItem> CartItems { get; set; }
        public virtual ICollection<Payment> Payments { get; set; }
    }
}
