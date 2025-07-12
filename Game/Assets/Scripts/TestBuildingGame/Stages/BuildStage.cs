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
    public class BuildStage : ITurnUser, IUpdatable, ISystemUser
    {
        private TaskCompletionSource<bool> _tcs;
        private TerrainSelector _terrainSelector;
        private BuildingCreation _buildings;
        private Assigner _assigner;

        public ValueTask ExecuteTurnAsync()
        {
            _tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            Debug.Log("BuildStage: ExecuteTurnAsync");
            
            return new ValueTask(_tcs.Task);
        }

        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _tcs.SetResult(true);
            }

            if (Input.GetMouseButtonDown(0))
            {
                _terrainSelector.SelectAt(Camera.main.ScreenToWorldPoint(Input.mousePosition));
            }

            if (Input.GetKeyDown(KeyCode.B) && _terrainSelector.Selected is BuildingTerrain b)
            {
                _assigner.Assign(_terrainSelector.Selected,_buildings.Create());
            }
        }
        
        public IEnumerable<Type> GetRequiredSystems()
        {
            return new []
            {
                typeof(Assigner),
                typeof(TerrainSelector),
                typeof(BuildingCreation)
            };
        }

        public void Inject(IEnumerable<ISystem> systems)
        {
            _assigner = systems.OfType<Assigner>().FirstOrDefault();
            _buildings = systems.OfType<BuildingCreation>().FirstOrDefault();
            _terrainSelector = systems.OfType<TerrainSelector>().FirstOrDefault();
        }
    }
}