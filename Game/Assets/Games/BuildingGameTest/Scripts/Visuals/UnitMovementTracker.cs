using System.Collections.Generic;
using BuildingsTestGame;
using TDS.Components;
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
            if (entity .TryGetComponent(out IEventComponent eventComponent) && entity is DefaultUnit or Builder)
            {
                eventComponent.Subscribe(nameof(IPlacedOnTerrain.PlacedOn),new ActionHandler<PropertyChangeEvent<IGameTerrainComponent,IPlacedOnTerrain>>(x =>
                {
                    if (_units.TryGetValue(x.Owner.Entity, out var unitMonoBehaviour))
                    {
                        _units[entity].MoveTo(x.NewValue.Entity.Transform.Position);
                        return;
                    }
                    
                    unitMonoBehaviour = Instantiate(_prefab).GetComponent<UnitMonoBehaviour>();
            
                    _units[x.Owner.Entity] =unitMonoBehaviour;
                    unitMonoBehaviour.Unit = x.Owner.Entity;
                    unitMonoBehaviour.transform.position = x.Owner.Entity.Transform.Position;
                    unitMonoBehaviour.LastPosition =  x.Owner.Entity.Transform.Position;
                }));
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
    }
}