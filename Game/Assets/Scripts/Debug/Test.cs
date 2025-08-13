using BuildingsTestGame;
using TDS.Entities;
using UnityEngine;

namespace TDS
{
    [DefaultExecutionOrder(100)]
    public class Test : MonoBehaviour
    {
        [SerializeField] private Vector2Int _tileCount;
        [SerializeField] private Vector2Int _firstBuildingPosition;
        [SerializeField] private TileMapSetup _tileMapSetup;
        [SerializeField] private AssignStageAcc _assignStage;
        private BuildingGame _game;
        
        private void Awake()
        {
            _game = new BuildingGameFactory(_tileCount).Create();
            GetComponent<MapGizmosDebug>().Map = _game.Map;
            GetComponent<EntityLifespanTracker>().EntityRegisterEvents = _game.EntityRegisterEvents;
            
            _tileMapSetup.Map = _game.Map;
            _assignStage.BuildingGame = _game;
            
            new GameInitializer(_firstBuildingPosition).Handle(_game);
        }

        private void Update()
        {
            _game.Update();
        }
    }
}