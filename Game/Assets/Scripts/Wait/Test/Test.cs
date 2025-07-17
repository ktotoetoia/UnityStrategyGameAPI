using System;
using BuildingsTestGame;
using TDS.Entities;
using TDS.TurnSystem;
using TDS.Worlds;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TDS
{
    [DefaultExecutionOrder(100)]
    public class Test : MonoBehaviour
    {
        [SerializeField] private Vector2Int _size;
        [SerializeField] private Vector2Int _firstBuildingPosition;
        private BuildingGame _game;
        
        private void Awake()
        {
            _game = new BuildingGameFactory(_size){StartingPosition = _firstBuildingPosition }.Create();
            GetComponent<MapUIDebug>().Map = _game.World.Map;
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

            if (_game.GameContext.Selector.Selection.First != null)
            {
                Gizmos.color = Color.blue;
                Gizmos.DrawSphere(_game.GameContext.Selector.GetSelectionOfType<ITerrain>().First.Area.Position,0.2f);
            }
        }
    }
}