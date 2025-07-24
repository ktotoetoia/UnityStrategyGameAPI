using System.Collections.Generic;

namespace TDS.Events
{
    public interface IEventHandler
    {
        bool CanHandle(IEvent evt);
        void Handle(IEvent evt);
    }
}