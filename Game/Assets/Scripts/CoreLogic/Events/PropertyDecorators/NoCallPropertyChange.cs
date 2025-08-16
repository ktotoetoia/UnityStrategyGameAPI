using TDS.Handlers;

namespace TDS.Events
{
    public class NoCallPropertyChange<T> : ICallPropertyChange<T>
    {
        public object Owner { get; }
        public T Value { get; set; }

        public NoCallPropertyChange(object owner, T value)
        {
            Owner = owner;
            Value = value;
        }

        public NoCallPropertyChange(object owner)
        {
            Owner = owner;
        }
        
        public void Subscribe<TOwner>(IHandler<PropertyChangeEvent<T, TOwner>> handler)
        {
            
        }

        public void Unsubscribe<TOwner>(IHandler<PropertyChangeEvent<T, TOwner>> handler)
        {
            
        }
    }
}