using System;
using System.Collections.Generic;
using BuildingsTestGame;
using TDS.Entities;
using TDS.Events;
using UnityEngine;

namespace TDS
{
    public class BuildingTracker : MonoBehaviour, IEntityObserver
    {
        [SerializeField] private GameObject _prefab;
        private Dictionary<IEntity, BuildingMonoBehaviour> _buildings = new();
        
        public void Add(IEntity entity)
        {
            if (entity.TryGetComponent(out IBuildingComponent buildingComponent )&& entity.TryGetComponent(out IEventComponent eventComponent))
            {
                eventComponent.Subscribe(new SingleTimeEventHandler<EntityInitializedEvent>(InitBuilding,eventComponent));
            }
        }

        private void InitBuilding(EntityInitializedEvent init)
        {
            BuildingMonoBehaviour buildingMonoBehaviour = Instantiate(_prefab).GetComponent<BuildingMonoBehaviour>();
            
            _buildings[init.Entity] = buildingMonoBehaviour ?? throw new NullReferenceException();
            buildingMonoBehaviour.Building = init.Entity;
            buildingMonoBehaviour.transform.position = init.Entity.GetComponent<IMovementOnTerrain>().Terrain.Entity.Transform.Position;
        }

        public void Remove(IEntity entity)
        {
            if (entity.TryGetComponent(out IBuildingComponent buildingComponent )&& entity.TryGetComponent(out IEventComponent eventComponent))
            {
                Destroy(_buildings[entity]);
                _buildings.Remove(entity);
            }
        }
    }
}