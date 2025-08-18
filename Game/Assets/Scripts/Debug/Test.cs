using System.Collections.Generic;
using System.Linq;
using BuildingsTestGame;
using TDS.Entities;
using TDS.Maps;
using TDS.SelectionSystem;
using UnityEngine;

namespace TDS
{
    [DefaultExecutionOrder(100)]
    public class Test : MonoBehaviour, IGameServiceLocator
    {
        [SerializeField] private Vector2Int _tileCount;
        [SerializeField] private Vector2Int _firstBuildingPosition;
        [SerializeField] private TileMapSetup _tileMapSetup;
        [SerializeField] private AssignStageAcc _assignStage;
        private BuildingGame _game;
        private List<IGameService> _services = new ();
        
        private void Awake()
        {
            _game = new BuildingGameFactory(_tileCount).Create();
            GetComponent<MapGizmosDebug>().Map = _game.Map;
            GetComponent<EntityLifespanTracker>().EntityRegisterEvents = _game.EntityRegisterEvents;
            
            _tileMapSetup.Map = _game.Map;
            _assignStage.BuildingGame = _game;
            
            new GameInitializer(_firstBuildingPosition).Handle(_game);

            _services.Add(new MoveService(() => _game.CurrentStage == _game.AssignStage,new MapPathfinder(_game.Map),new TerrainSelectionProvider(_game.Map), GetComponent<ISelector>()));
            _services.Add(new EndTurnService(() => _game.CurrentStage == _game.AssignStage, _game.AssignStage));
        }

        private void Update()
        {
            _game.Update();
        }

        public T GetService<T>() where T : IGameService
        {
            return _services.OfType<T>().FirstOrDefault();
        }
    }
}