using System.Collections.Generic;
using System.Linq;
using TDS.Handlers;

namespace TDS.Events
{
    public class PropertyChangeRegistry : IPropertyChangeRegistry
    {
        public IPropertyChangeBinder ChangeBinder { get; }
        public IEnumerable<object> Source { get; set; }

        public PropertyChangeRegistry() : this(new List<object>(), new PropertyChangeBinder())
        {
            
        }

        public PropertyChangeRegistry(IEnumerable<object> source) : this(source, new PropertyChangeBinder())
        {
            
        }

        public PropertyChangeRegistry(IEnumerable<object> source, IPropertyChangeBinder changeBinder)
        {
            Source = source;
            ChangeBinder = changeBinder;
        }

        public void Subscribe<TPropertyType, TOwnerType>(
            string propertyName,
            IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler)
        {
            foreach (TOwnerType owner in Source.OfType<TOwnerType>())
            {
                ChangeBinder.Subscribe(owner, propertyName, handler);
            }
        }

        public void Unsubscribe<TPropertyType, TOwnerType>(
            string propertyName,
            IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler)
        {
            foreach (TOwnerType owner in Source.OfType<TOwnerType>())
            {
                ChangeBinder.Unsubscribe(owner, propertyName, handler);
            }
        }
    }
}