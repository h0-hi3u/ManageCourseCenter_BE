using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.PaymentDto
{
    public class CreatePaymentDto
    {
        public int CartId { get; set; }
        public DateTime CreateTime { get; set; }
        public DateTime PaidTime { get; set; }
        public int Method { get; set; }
        public int Status { get; set; }
    }
}
