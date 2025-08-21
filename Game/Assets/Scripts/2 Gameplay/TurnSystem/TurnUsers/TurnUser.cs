using System;
using System.Threading.Tasks;

namespace TDS.TurnSystem
{
    public class TurnUser : ITurnUserManual
    {
        public event Action OnTurnStart;
        public event Action OnTurnEnd;
        
        private TaskCompletionSource<bool> _completion;
        
        public ValueTask ExecuteTurnAsync()
        {
            _completion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            
            OnStart();
            
            return new ValueTask(_completion.Task);
        }

        protected virtual void OnStart()
        {
            OnTurnStart?.Invoke();
        }

        protected virtual void OnEnd()
        {
            OnTurnEnd?.Invoke();
        }

        public void EndTurn()
        {
            if (_completion == null)
            {
                return;
            }
            
            OnEnd();
            _completion.SetResult(true);
        }
    }
}