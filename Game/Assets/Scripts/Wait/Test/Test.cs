using BuildingsTestGame;
using TDS.Entities;
using TDS.TurnSystem;
using TDS.UI;
using UnityEngine;

namespace TDS
{
    [DefaultExecutionOrder(100)]
    public class Test : MonoBehaviour
    {
        [SerializeField] private TurnBasedUI _ui;
        [SerializeField] private Vector2Int _size;
        private TurnBasedGame _game;

        private void Awake()
        {
            _game = new BuildingGameFactory(_size).Create();
            GetComponent<MapUIDebug>().Map = _game.World.Map;
            
        }

        private void Update()
        {
            _game.Update();
            
            if (_game.TurnSwitcher.CurrentUser is IUpdatable u)
            {
                u.Update();
            }
        }
    }
}