using System;

namespace TDS.Commands
{
    public class ActionCommandHandler<TCommand> : ICommandHandler where TCommand : ICommand
    {
        public Action<TCommand> CommandAction { get; set; }

        public ActionCommandHandler(Action<TCommand> commandAction)
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