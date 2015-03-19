using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRTVU.EMS.Domain.Events
{
    public class ContactModifiedEvent : DomainEvent
    {
        public ContactModifiedEvent(IEntity source) : base(source) { }

        public string Phone { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string District { get; set; }

        public string Address { get; set; }

        public bool IsByPost { get; set; }
    }
}
