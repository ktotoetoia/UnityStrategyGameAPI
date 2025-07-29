using BuildingsTestGame;
using TDS.Entities;
using TDS.Events;
using TDS.Handlers;
using UnityEngine;
using UnityEngine.Serialization;

namespace TDS
{
    [DefaultExecutionOrder(100)]
    public class Test : MonoBehaviour, IHandler<IEvent>
    {
        [FormerlySerializedAs("_size")] [SerializeField] private Vector2Int _tileCount;
        [SerializeField] private Vector2 _tileSize;
        [SerializeField] private Vector2Int _firstBuildingPosition;
        [SerializeField] private BuildingGameUI _buildingGameUI;
        [SerializeField] private int _f;
        [SerializeField] private AssignStageLegacyInput _assignStageInput;
        [SerializeField] private TerrainDistributor _terrainDistributor;
        private BuildingGame _game;
        
        private void Awake()
        {
            _game = new BuildingGameFactory(_tileCount) {TileSize = _tileSize,StartingPosition = _firstBuildingPosition }.Create();
            GetComponent<MapUIDebug>().Map = _game.Map;
            GetComponent<EntityLifespanTracker>().EntityRegisterEvents = _game.EntityRegisterEvents;
            _terrainDistributor.Game = _game;
            _buildingGameUI.Game = _game;
            _game.MapEvents.Subscribe(this);
            _assignStageInput.BuildingGame = _game;
        }

        private void Update()
        {
            _game.Update();
        }

        private void OnDrawGizmos()
        {
            if (_game == null)
            {
                return;
            }

            Gizmos.color = Color.blue;
        }

        public bool CanHandle(IEvent evt)
        {
            return true;
        }

        public void Handle(IEvent evt)
        {
            if(evt is PropertyChangeEvent<IEntity,BuildingTerrain> asd)
            {
                Debug.Log(asd.OldValue);
                Debug.Log(asd.NewValue);
            }
        }
    }
}