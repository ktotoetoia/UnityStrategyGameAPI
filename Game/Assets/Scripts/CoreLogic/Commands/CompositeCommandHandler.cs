using System.Collections.Generic;

namespace TDS.Commands
{
    public class CompositeCommandHandler : ICommandHandler
    {
        public IEnumerable<ICommandHandler> Handlers { get; }

        public CompositeCommandHandler(List<ICommandHandler> handlers)
        {
            Handlers = handlers;
        }
        
        public bool CanDoCommand(ICommand command)
        {
            return CanDoCommand(command, out ICommandHandler listener);
        }

        public void DoCommand(ICommand command)
        {
            if (CanDoCommand(command, out var listener))
            {
                listener.DoCommand(command);
            }
        }

        private bool CanDoCommand(ICommand command, out ICommandHandler result)
        {
            foreach (ICommandHandler handler in Handlers)
            {
                if (handler.CanDoCommand(command))
                {
                    result = handler;
                    return true;
                }
            }
            
            result = null;
            return false;
        }

        public class CommandHandler<T> : ICommandHandler 
            where T : class,ICommand
        {
            public virtual bool CanDoCommand(ICommand command)
            {
                return command is T;
            }

            public virtual void DoCommand(ICommand command)
            {
                throw new System.NotImplementedException();
            }

            public virtual bool CanDoCommand(ICommand command, out T result)
            {
                if (CanDoCommand(command))
                {
                    result = command as T;
                    return true;
                }
                
                result = null;
                return false;
            }
        }
    }
}