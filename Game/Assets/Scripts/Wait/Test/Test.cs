using BuildingsTestGame;
using TDS.Entities;
using TDS.Worlds;
using UnityEngine;

namespace TDS
{
    [DefaultExecutionOrder(100)]
    public class Test : MonoBehaviour
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
    }
}