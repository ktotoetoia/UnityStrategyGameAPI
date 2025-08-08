using TDS.Handlers;

namespace TDS.Events
{
    public static class HandlerExtensions
    {
        public static bool TryHandle<T>(this IConditionalHandler<T> handler, T operation)
        {
            if (handler.CanHandle(operation))
            {
                handler.Handle(operation);

                return true;
            }
            
            return false;
        }
    }
}