using TDS.Events;

namespace TDS.Components
{
    public interface IEventComponent : IComponent, IEventBus, IPropertyChangeRegistry
    {
        
    }
}