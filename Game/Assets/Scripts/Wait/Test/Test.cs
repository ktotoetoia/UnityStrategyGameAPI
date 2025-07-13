using BuildingsTestGame;
using TDS.Entities;
using TDS.TurnSystem;
using UnityEngine;
using UnityEngine.InputSystem;

namespace TDS
{
    [DefaultExecutionOrder(100)]
    public class Test : MonoBehaviour
    {
        [SerializeField] private Vector2Int _size;
        private BuildingGame _game;
        
        private void Awake()
        {
            _game = new BuildingGameFactory(_size).Create();
            GetComponent<MapUIDebug>().Map = _game.World.Map;
        }

        private void Update()
        {
            _game.Update();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _game.CurrentStage.CommandListener.DoCommand(new EndTurnCommand());
            }

            if (Input.GetMouseButtonDown(0))
            {
                _game.CurrentStage.CommandListener.DoCommand(new SelectCommand(Camera.main.ScreenToWorldPoint(Input.mousePosition)));
            }
        }
    }
}