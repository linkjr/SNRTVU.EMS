using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRTVU.EMS.Domain.Models
{
    public class AccountFee : AggregateRoot
    {
        public decimal BillingAmount { get; set; }

        public string StudentID { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
