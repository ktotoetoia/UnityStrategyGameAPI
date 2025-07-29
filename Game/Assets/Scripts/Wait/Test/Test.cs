using BuildingsTestGame;
using TDS.Entities;
using TDS.Events;
using TDS.Handlers;
using UnityEngine;

namespace TDS
{
    [DefaultExecutionOrder(100)]
    public class Test : MonoBehaviour, IHandler<PropertyChangeEvent<IEntity,BuildingTerrain>>
    {
        [SerializeField] private Vector2Int _tileCount;
        [SerializeField] private Vector2Int _firstBuildingPosition;
        [SerializeField] private BuildingGameUI _buildingGameUI;
        [SerializeField] private int _f;
        [SerializeField] private AssignStageLegacyInput _assignStageInput;
        [SerializeField] private TileMapSetup tileMapSetup;
        private BuildingGame _game;
        
        private void Awake()
        {
            _game = new BuildingGameFactory(_tileCount) {StartingPosition = _firstBuildingPosition }.Create();
            GetComponent<MapUIDebug>().Map = _game.Map;
            GetComponent<EntityLifespanTracker>().EntityRegisterEvents = _game.EntityRegisterEvents;
            tileMapSetup.Game = _game;
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
        
        public bool CanHandle(PropertyChangeEvent<IEntity, BuildingTerrain> operation)
        {
            return true;
        }

        public void Handle(PropertyChangeEvent<IEntity, BuildingTerrain> operation)
        {
            Debug.Log(operation.OldValue);
            Debug.Log(operation.NewValue);
        }
    }
}