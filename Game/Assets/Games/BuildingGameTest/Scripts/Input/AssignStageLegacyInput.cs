using UnityEngine;

namespace BuildingsTestGame
{
    public class AssignStageLegacyInput : MonoBehaviour
    {
        private AssignStageAcc _acc;
        
        private void Awake()
        {
            _acc = GetComponent<AssignStageAcc>();
        }

        private void Update()
        {
            if (_acc.BuildingGame != null && _acc.BuildingGame.CurrentStage == _acc.BuildingGame.AssignStage)
            {
                HandleInput();
            }
        }
        
        private void HandleInput()
        {
            if (Input.GetMouseButtonDown(1))
            {
                _acc.MoveUnit();
            }
        }
    }
}