using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCC.DAL.Dto.PaymentDto
{
    public class UpdatePaymentStatusDto
    {
        public int Id { get; set; }
        public int Status { get; set; }
    }
}
