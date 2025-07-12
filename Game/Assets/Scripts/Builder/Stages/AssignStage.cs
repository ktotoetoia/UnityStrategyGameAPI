using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDS;
using TDS.Systems;
using TDS.TurnSystem;
using UnityEngine;

namespace BuildingsTestGame
{
    public class AssignStage : ITurnUser, IUpdatable, ISystemUser
    {
        private UnitCreation _unitCreation;
        private UnitAssigner _unitAssigner;
        private TerrainSelector _terrainSelector;
        private TaskCompletionSource<bool> _tcs;
        private int _cap = 3;
        private int _created = 0;
        
        public ValueTask ExecuteTurnAsync()
        {
            _tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            Debug.Log("AssignStage: ExecuteTurnAsync");
            _created = 0;
            return new ValueTask(_tcs.Task);
        }

        public void Update()
        {
            Debug.Log("Update Stage");

            if (Input.GetMouseButtonDown(0))
            {
                _terrainSelector.SelectAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }

            if (Input.GetKeyDown(KeyCode.C )&& _created < _cap && _terrainSelector.IsSelected)
            {
                _unitAssigner.Assign(_terrainSelector.Selected, _unitCreation.Create());
                
                _created++;
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _tcs.SetResult(true);
            }
        }

        public IEnumerable<Type> GetRequiredSystems()
        {
            return new []
            {
                typeof(UnitCreation),
                typeof(UnitAssigner),
                typeof(TerrainSelector),
            };
        }

        public void Inject(IEnumerable<ISystem> systems)
        {
            _terrainSelector = systems.OfType<TerrainSelector>().FirstOrDefault();
            _unitCreation = systems.OfType<UnitCreation>().FirstOrDefault();
            _unitAssigner = systems.OfType<UnitAssigner>().FirstOrDefault();
        }
    }
}