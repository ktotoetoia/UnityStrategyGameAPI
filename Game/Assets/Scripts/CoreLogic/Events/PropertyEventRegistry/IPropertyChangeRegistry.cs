using System.Collections.Generic;
using TDS.Handlers;

namespace TDS.Events
{
    public interface IPropertyChangeRegistry
    {
         IEnumerable<object> Source { get; }
        
        void Subscribe<TPropertyType, TOwnerType>(
            string propertyName,
            IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler);

        void Unsubscribe<TPropertyType, TOwnerType>(
            string propertyName,
            IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler);
    }

    public interface IPropertyChangeBinder
    {
        void Subscribe<TPropertyType, TOwnerType>(object obj, string propertyName,
            IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler);

        void Unsubscribe<TPropertyType, TOwnerType>(object obj,
            string propertyName,
            IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler);
    }
}