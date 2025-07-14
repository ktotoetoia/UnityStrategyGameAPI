using System.Collections.Generic;

namespace TDS.Commands
{
    public class CommandListener : ICommandListener
    {
        public IEnumerable<ICommandListener> Listeners { get; }

        public CommandListener(List<ICommandListener> listeners)
        {
            Listeners = listeners;
        }
        
        public bool CanDoCommand(ICommand command)
        {
            return CanDoCommand(command, out ICommandListener listener);
        }

        public void DoCommand(ICommand command)
        {
            if (CanDoCommand(command, out var listener))
            {
                listener.DoCommand(command);
            }
        }

        private bool CanDoCommand(ICommand command, out ICommandListener listener)
        {
            foreach (ICommandListener commandListener in Listeners)
            {
                if (commandListener.CanDoCommand(command))
                {
                    listener = commandListener;
                    return true;
                }
            }
            
            listener = null;
            return false;
        }
    }
}