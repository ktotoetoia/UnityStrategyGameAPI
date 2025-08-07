using System;
using System.Collections.Generic;
using BuildingsTestGame;
using TDS.Entities;
using TDS.Events;
using TDS.Handlers;
using UnityEngine;

namespace TDS
{
    public class UnitMovementTracker : MonoBehaviour, IEntityObserver
    {
        [SerializeField] private GameObject _prefab;
        private Dictionary<IEntity, UnitMonoBehaviour> _units = new();
        
        public void Add(IEntity entity)
        {
            if (entity .TryGetComponent(out IEventComponent eventComponent) && entity is DefaultUnit)
            {
                eventComponent.Subscribe(new SingleTimeEventHandler<EntityInitializedEvent>(InitializeUnit,eventComponent));
            }
        }

        public void Remove(IEntity entity)
        {
            if (_units.ContainsKey(entity))
            {
                Destroy(_units[entity]);
                _units.Remove(entity);
            }
        }

        private void InitializeUnit(EntityInitializedEvent created)
        {
            UnitMonoBehaviour unitMonoBehaviour = Instantiate(_prefab).GetComponent<UnitMonoBehaviour>();

            if (unitMonoBehaviour is null)
            {
                throw new NullReferenceException();
            }

            if (created.Entity.TryGetComponent(out IEventComponent eventComponent))
            {
                eventComponent.Subscribe(new ActionHandler<PropertyChangeEvent<IGameTerrain, ITerrainComponent>>(UpdateUnit));
            }
            
            _units[created.Entity] =unitMonoBehaviour;
            unitMonoBehaviour.Unit = created.Entity;
            _prefab.transform.position = created.Entity.Transform.Position;
        }

        private void UpdateUnit(PropertyChangeEvent<IGameTerrain, ITerrainComponent> eve)
        {
            _units[eve.Owner.Entity].MoveTo(eve.NewValue.Area.Position);
        }
    }
}