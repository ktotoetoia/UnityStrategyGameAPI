using System;
using System.Collections.Generic;
using BuildingsTestGame;
using TDS.Entities;
using TDS.Events;
using TDS.Handlers;
using UnityEngine;

namespace TDS
{
    public class BuildingTracker : MonoBehaviour, IEntityObserver
    {
        [SerializeField] private GameObject _prefab;
        private Dictionary<IEntity, BuildingMonoBehaviour> _buildings = new();
        
        public void Add(IEntity entity)
        {
            if (entity is FirstBuilding && entity.TryGetComponent(out IEventComponent eventComponent))
            {
                eventComponent.Subscribe(nameof(IPlacedOnTerrain.PlacedOn),new ActionHandler<PropertyChangeEvent<IGameTerrainComponent,IPlacedOnTerrain>>(x =>
                {
                    if (!_buildings.TryGetValue(x.Owner.Entity, out var buildingMonoBehaviour))
                    {
                        buildingMonoBehaviour = Instantiate(_prefab).GetComponent<BuildingMonoBehaviour>();
                    }
                    
                    _buildings[x.Owner.Entity] = buildingMonoBehaviour ?? throw new NullReferenceException();
                    buildingMonoBehaviour.Building = x.Owner.Entity;
                    buildingMonoBehaviour.transform.position = x.Owner.Entity.GetComponent<IPlacedOnTerrain>().PlacedOn.Entity.Transform.Position;
                }));
            }
        }
        
        public void Remove(IEntity entity)
        {
            if (entity.TryGetComponent(out IEntityCreationComponent buildingComponent )&& entity.TryGetComponent(out IEventComponent eventComponent))
            {
                Destroy(_buildings[entity]);
                _buildings.Remove(entity);
            }
        }
    }
}