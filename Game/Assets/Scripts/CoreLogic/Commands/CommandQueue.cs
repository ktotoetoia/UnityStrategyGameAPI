using System.Collections.Generic;

namespace TDS.Commands
{
    public class CommandQueue : ICommandQueue
    {
        private readonly ICommandHandler _handler;
        private readonly Queue<ICommand> _queue = new();
        private ICommand _current;

        public IReadOnlyCollection<ICommand> CommandsToDo => _queue;
        public ICommand Current => _current;

        public CommandQueue(ICommandHandler handler)
        {
            _handler = handler;
        }

        public void Enqueue(ICommand command)
        {
            _queue.Enqueue(command);

            if (_current == null)
            {
                TryRunNext();
            }
        }

        private void TryRunNext()
        {
            if (_queue.Count == 0)
            {
                _current = null;
                return;
            }
            
            _current = _queue.Dequeue();

            if (_handler.CanDoCommand(_current))
            {
                _handler.DoCommand(_current);
            
                return;
            }
            
            CompleteCurrent();
        }

        public void CompleteCurrent()
        {
            TryRunNext();
        }
    }
}