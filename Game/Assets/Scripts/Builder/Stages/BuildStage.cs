using System;
using System.Threading.Tasks;
using TDS;
using TDS.TurnSystem;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildStage : ITurnUser, IUpdatable
    {
        private TaskCompletionSource<bool> _tcs;
        
        public ValueTask ExecuteTurnAsync()
        {
            _tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            Debug.Log("BuildStage: ExecuteTurnAsync");
            
            return new ValueTask(_tcs.Task);
        }

        public void Update()
        {
            Debug.Log("Update Stage");

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _tcs.SetResult(true);
            }
        }
    }
}