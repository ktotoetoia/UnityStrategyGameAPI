using BuildingsTestGame;
using TDS.Entities;
using TDS.Events;
using UnityEngine;

namespace TDS
{
    [DefaultExecutionOrder(100)]
    public class Test : MonoBehaviour, IEventHandler
    {
        [SerializeField] private Vector2Int _size;
        [SerializeField] private Vector2Int _firstBuildingPosition;
        [SerializeField] private BuildingGameUI _buildingGameUI;
        [SerializeField] private int _f;
        private BuildingGame _game;
        
        private void Awake()
        {
            _game = new BuildingGameFactory(_size){StartingPosition = _firstBuildingPosition }.Create();
            GetComponent<MapUIDebug>().Map = _game.World.Map;
            _buildingGameUI.Game = _game;
            _game.WorldEventBus.Subscribe(this);
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
            if(evt is PropertyChangeEvent<IUnit,BuildingTerrain> asd)
            {
                Debug.Log(asd.OldValue);
                Debug.Log(asd.NewValue);
            }
        }
    }
}