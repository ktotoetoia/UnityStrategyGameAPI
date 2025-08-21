using TDS.Handlers;

namespace TDS.Events
{
    public interface ICallPropertyChange<T>
    {
        T Value { get; set; }
        public void Subscribe<TOwner>(IHandler<PropertyChangeEvent<T, TOwner>> handler);
        public void Unsubscribe<TOwner>(IHandler<PropertyChangeEvent<T, TOwner>> handler);
        public bool IsSubscribed<TOwner>(IHandler<PropertyChangeEvent<T, TOwner>> handler);
    }
}