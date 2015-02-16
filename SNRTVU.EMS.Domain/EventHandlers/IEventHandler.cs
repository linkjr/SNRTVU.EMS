using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Domain.Events;

namespace SNRTVU.EMS.Domain.EventHandlers
{
    public interface IEventHandler<in TEvent>
         where TEvent : class, IEvent
    {
        void Handle(TEvent evnt);
    }
}
