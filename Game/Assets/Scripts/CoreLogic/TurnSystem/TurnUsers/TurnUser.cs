using System.Threading.Tasks;

namespace TDS.TurnSystem
{
    public class TurnUser : ITurnUserManual
    {
        private TaskCompletionSource<bool> _completion;
        
        public ValueTask ExecuteTurnAsync()
        {
            _completion = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            
            OnStart();
            
            return new ValueTask(_completion.Task);
        }

        protected virtual void OnStart()
        {
            
        }

        protected virtual void BeforeEnd()
        {
            
        }

        public void EndTurn()
        {
            BeforeEnd();
            _completion.SetResult(true);
        }
    }
}