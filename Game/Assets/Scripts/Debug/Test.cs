using BuildingsTestGame;
using TDS.Entities;
using TDS.SelectionSystem;
using UnityEngine;

namespace TDS
{
    [DefaultExecutionOrder(100)]
    public class Test : MonoBehaviour
    {
        [SerializeField] private Vector2Int _tileCount;
        [SerializeField] private Vector2Int _firstBuildingPosition;
        [SerializeField] private TileMapSetup _tileMapSetup;
        [SerializeField] private MovementDebug _movementDebug;
        [SerializeField] private BuildingGameUI _buildingGameUI;
        private BuildingGame _game;
        
        private void Awake()
        {
            _game = new BuildingGameFactory(_tileCount).Create();
            GetComponent<EntityLifespanTracker>().EntityRegisterEvents = _game.EntityRegistry;
            new GameInitializer(_firstBuildingPosition).Handle(_game);
            
            GetComponent<MapGizmosDebug>().Map = _game.Map;
            GetComponent<LegacyInput>().AssignStage = _game.PlayerStage;
            GetComponent<LegacyInput>().Map = _game.Map;
            
            _tileMapSetup.Map = _game.Map;
            _movementDebug.Map = _game.Map;
            _buildingGameUI.PlayerStage  = _game.PlayerStage;
            
        }

        private void Update()
        {
            _game.Update();
        }
    }
}