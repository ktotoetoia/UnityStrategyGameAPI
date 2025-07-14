using TDS.Commands;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildStageLegacyInput : IInputHandler
    {
        public void HandleInput(ICommandListener listener)
        { 
            if (Input.GetKeyDown(KeyCode.Space))
            {
                listener.DoCommand(new EndTurnCommand());
            }
        }
    }
}