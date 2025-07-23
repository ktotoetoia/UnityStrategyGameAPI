using System.Collections.Generic;

namespace TDS.Commands
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        void Handle(TEvent evt);
    }
}