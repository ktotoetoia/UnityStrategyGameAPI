using System;

namespace TDS.Commands
{
    public class ActionCommandListener<T> : ICommandListener where T : ICommand
    {
        public Action<T> CommandAction { get; set; }

        public ActionCommandListener(Action<T> commandAction)
        {
            CommandAction = commandAction;
        }
        
        public bool CanDoCommand(ICommand command)
        {
            return command is T;
        }

        public void DoCommand(ICommand command)
        {
            if (!CanDoCommand(command))
            {
                throw new ArgumentException();
            }

            if (command is T t)
            {
                CommandAction(t);
            }
        }
    }
}