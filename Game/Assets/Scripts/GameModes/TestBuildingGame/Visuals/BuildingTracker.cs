using System;
using System.Collections.Generic;
using BuildingsTestGame;
using TDS.Entities;
using UnityEngine;

namespace TDS
{
    public class BuildingTracker : MonoBehaviour, IEntityObserver
    {
        [SerializeField] private GameObject _prefab;
        private Dictionary<IBuilding, BuildingMonoBehaviour> _buildings = new();
        
        public void Add(IEntity entity)
        {
            if (entity is IBuilding building)
            {
                InitBuilding(building);
            }
        }

        private void InitBuilding(IBuilding building)
        {
            BuildingMonoBehaviour buildingMonoBehaviour = Instantiate(_prefab).GetComponent<BuildingMonoBehaviour>();

            if (buildingMonoBehaviour is null)
            {
                throw new NullReferenceException();
            }
            
            _buildings[building] = buildingMonoBehaviour;
            buildingMonoBehaviour.Building = building;
        }

        public void Remove(IEntity entity)
        {
            if (entity is IBuilding building)
            {
                Destroy(_buildings[building]);
                _buildings.Remove(building);
            }
        }
    }
}