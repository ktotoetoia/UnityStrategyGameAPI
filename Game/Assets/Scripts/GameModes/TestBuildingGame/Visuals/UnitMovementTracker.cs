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
        [SerializeField] private float _speed;
        private Dictionary<IEntity, UnitMonoBehaviour> _units = new();
        private List<Movement>  _movements = new List<Movement>();
        
        public void Add(IEntity entity)
        {
            if (entity .TryGetComponent(out IEventComponent eventComponent) && entity is DefaultUnit)
            {
                eventComponent.Subscribe(new SingleTimeEventHandler<UnitCreatedEvent>(InitializeUnit,eventComponent));
            }
        }

        public void Remove(IEntity entity)
        {
            Destroy(_units[entity]);
            _units.Remove(entity);
        }

        private void InitializeUnit(UnitCreatedEvent created)
        {
            UnitMonoBehaviour unitMonoBehaviour = Instantiate(_prefab).GetComponent<UnitMonoBehaviour>();

            if (unitMonoBehaviour is null)
            {
                throw new NullReferenceException();
            }
            
            created.Unit.Events.Subscribe(new ActionHandler<UnitMovedEvent>(UpdateUnit));

            _units[created.Unit] =unitMonoBehaviour;
            unitMonoBehaviour.Unit = created.Unit;
            _prefab.transform.position = created.Unit.Transform.Position;
        }

        private void UpdateUnit(UnitMovedEvent movedEvent)
        {
            MoveUnitCommand command = movedEvent.Command;
            _movements.Add(new Movement(_units[command.Unit].transform.position,command.Unit.Transform.Position,command.Unit));
        }

        private void Update()
        {
            foreach (Movement movement in _movements)
            {
                _units[movement.Entity].transform.position = Vector3.Lerp(movement.From,movement.To,movement.Bomb += _speed * Time.deltaTime);
            }
        }

        private class Movement
        {
            public Vector3 From { get; }
            public Vector3 To { get; }
            public IEntity Entity { get; }
            
            public float Bomb { get; set; }
            
            public Movement(Vector3 from, Vector3 to, IEntity entity)
            {
                From = from;
                To = to;
                Entity = entity;
            }
        }
    }
}