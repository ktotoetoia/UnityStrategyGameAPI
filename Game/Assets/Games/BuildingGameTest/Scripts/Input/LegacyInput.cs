using TDS.Entities;
using TDS.Maps;
using TDS.SelectionSystem;
using UnityEngine;

namespace BuildingsTestGame
{
    public class LegacyInput : MonoBehaviour
    {
        private MoveService _moveService;
        private EndTurnService _endTurnService;
        private IGameStage _assignStage;
        private ISelector  _selector;
        private IMap _map;
        private ISelectionProvider _terrainSelector;

        public IGameStage AssignStage
        {
            get => _assignStage;
            set
            {
                _assignStage = value;
                _moveService = _assignStage.GetService<MoveService>();
                _endTurnService = _assignStage.GetService<EndTurnService>();
            }
        }

        public IMap Map
        {
            get => _map;
            set
            {
                _map = value;
                _terrainSelector = new TerrainSelectionProvider(_map);
            }
        }

        private void Awake()
        {
            _selector = gameObject.GetComponent<ISelector>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(1))
            {
                Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                ITerrainArea targetTerrain = _terrainSelector.SelectAt<ITerrain>(clickPosition).First.TerrainArea;
                IEntity unit = _selector.GetSelection<IEntity>().First;
                
                _moveService.Move(unit, targetTerrain);
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _endTurnService.EndTurn();
            }
        }
    }
}