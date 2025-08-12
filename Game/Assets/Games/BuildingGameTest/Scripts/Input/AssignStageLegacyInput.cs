using UnityEngine;

namespace TDS
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
            if (Input.GetKeyDown(KeyCode.C))
            {
                _acc.CreateUnit();
            }

            if (Input.GetMouseButtonDown(1))
            {
                _acc.MoveUnit();
            }
        }
    }
}