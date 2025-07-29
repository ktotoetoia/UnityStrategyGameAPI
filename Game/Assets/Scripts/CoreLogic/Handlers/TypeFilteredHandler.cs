using System;

namespace TDS.Handlers
{
    public class TypeFilteredHandler<TTarget, TInput> : IHandler<TInput>
    {
        private readonly Action<TTarget> _handler;

        public TypeFilteredHandler(Action<TTarget> handler)
        {
            _handler = handler;
        }

        public bool CanHandle(TInput input)
        {
            return input is TTarget;
        }

        public void Handle(TInput input)
        {
            if (input is TTarget casted)
            {
                _handler(casted);
            }
        }
    }
}