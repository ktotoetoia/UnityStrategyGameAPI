using TDS.Handlers;

namespace TDS.Events
{
    public class HandlerWrapper<T, TOwner> : IHandler<IPropertyChangeEvent>
    {
        public IHandler<PropertyChangeEvent<T, TOwner>> Inner { get; }

        public HandlerWrapper(IHandler<PropertyChangeEvent<T, TOwner>> inner)
        {
            Inner = inner;
        }

        public void Handle(IPropertyChangeEvent evt)
        {
            if (evt is PropertyChangeEvent<T, object> objEvt)
            {
                if (objEvt.Owner is TOwner ownerTyped)
                {
                    var typedEvt = new PropertyChangeEvent<T, TOwner>(
                        objEvt.OldValue,
                        objEvt.NewValue,
                        ownerTyped);

                    Inner.Handle(typedEvt);
                }
            }
        }
    }
}