﻿using BuildingsTestGame;
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
        [SerializeField] AssignStageLegacyInput _assignStageInput;
        private BuildingGame _game;
        
        private void Awake()
        {
            _game = new BuildingGameFactory(_size) { StartingPosition = _firstBuildingPosition }.Create();
            GetComponent<MapUIDebug>().Map = _game.Map;
            GetComponent<UnitTracker>().Game = _game;
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
            if(evt is PropertyChangeEvent<IUnit,BuildingTerrain> asd)
            {
                Debug.Log(asd.OldValue);
                Debug.Log(asd.NewValue);
            }
        }
    }
}