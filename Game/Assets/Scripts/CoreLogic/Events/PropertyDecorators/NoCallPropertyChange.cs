namespace TDS.Events
{
    public class NoCallPropertyChange<T, TOwner> : ICallPropertyChange<T, TOwner>
    {
        public TOwner Owner { get; }
        public T Value { get; set; }

        public NoCallPropertyChange(TOwner owner, T value)
        {
            Owner = owner;
            Value = value;
        }

        public NoCallPropertyChange(TOwner owner)
        {
            Owner = owner;
        }
    }
}