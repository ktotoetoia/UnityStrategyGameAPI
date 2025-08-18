using UnityEngine;

namespace BuildingsTestGame
{
    public class AssignStageLegacyInput : MonoBehaviour
    {
        private MoveService _moveService;
        private EndTurnService _endTurnService;

        private MoveService MoveService
        {
            get
            {
                return _moveService ??= GetComponent<IGameServiceLocator>().GetService<MoveService>();
            }
        }
        
        private EndTurnService EndTurnService
        {
            get
            {
                return _endTurnService ??= GetComponent<IGameServiceLocator>().GetService<EndTurnService>();
            }
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                MoveService.Move();
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                EndTurnService.EndTurn();
            }
        }
    }
}