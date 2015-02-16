using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SNRTVU.EMS.Domain.EventHandlers;
using SNRTVU.EMS.Infrastructure.Ioc;

namespace SNRTVU.EMS.Domain.Events
{
    public abstract class DomainEvent : IDomainEvent
    {
        public DomainEvent(IEntity source)
        {
            this.Source = source;
        }

        public IEntity Source
        {
            get;
            private set;
        }

        public static void Publish<TDomainEvent>(TDomainEvent evnt)
            where TDomainEvent : class, IDomainEvent
        {
            var handlers = ServiceLocator.Instance.ResolveAll<IDomainEventHandler<TDomainEvent>>();
            foreach (var handler in handlers)
            {
                handler.Handle(evnt);
            }
        }
    }
}
