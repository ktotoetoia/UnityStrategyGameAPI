using TDS.Handlers;

namespace TDS.Events
{
    public interface IPropertyEventBus
    {
        void Subscribe<TPropertyType, TOwnerType>(
            string propertyName,
            IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler);

        void Unsubscribe<TPropertyType, TOwnerType>(
            string propertyName,
            IHandler<PropertyChangeEvent<TPropertyType, TOwnerType>> handler);
    }
}