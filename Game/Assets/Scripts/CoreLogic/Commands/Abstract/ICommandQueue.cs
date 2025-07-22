using System.Collections.Generic;

namespace TDS.Commands
{
    public interface ICommandQueue
    {
        IReadOnlyCollection<ICommand> CommandsToDo { get; }
        ICommand Current { get; }
        
        void Enqueue(ICommand command);
        void CompleteCurrent();
    }
}