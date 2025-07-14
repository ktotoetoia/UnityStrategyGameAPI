using System;

namespace TDS.Commands
{
    public class ActionCommandListener<TCommand> : ICommandListener where TCommand : ICommand
    {
        public Action<TCommand> CommandAction { get; set; }

        public ActionCommandListener(Action<TCommand> commandAction)
        {
            CommandAction = commandAction;
        }
        
        public bool CanDoCommand(ICommand command)
        {
            return command is TCommand;
        }

        public void DoCommand(ICommand command)
        {
            if (!CanDoCommand(command))
            {
                throw new ArgumentException();
            }

            if (command is TCommand t)
            {
                CommandAction(t);
            }
        }
    }
}