using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNRTVU.EMS.Domain.Events
{
    public class PasswordChangedEvent : DomainEvent
    {
        public PasswordChangedEvent(IEntity source) : base(source) { }

        public string OldPassword { get; set; }

        public string NewPassword { get; set; }
    }
}
