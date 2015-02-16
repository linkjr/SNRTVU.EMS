using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Domain.Events;

namespace SNRTVU.EMS.Domain.EventHandlers
{
    public interface IDomainEventHandler<TDomainEvent> : IEventHandler<TDomainEvent>
          where TDomainEvent : class, IDomainEvent
    {
    }
}
