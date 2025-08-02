using System.Collections.Generic;
using BuildingsTestGame;
using TDS.Entities;
using TDS.Events;
using TDS.Handlers;
using UnityEngine;

namespace TDS
{
    public class EntityMovementTracker : MonoBehaviour, IEntityObserver
    {
        [SerializeField] private GameObject _prefab;
        [SerializeField] private float _speed;
        private Dictionary<IEntity, GameObject> _entities = new Dictionary<IEntity, GameObject>();
        private List<Movement>  _movements = new List<Movement>();
        
        public void Add(IEntity entity)
        {
            if (entity .TryGetComponent(out IEventComponent eventComponent))
            {
                eventComponent.Subscribe(new SingleTimeEventHandler<UnitCreatedEvent>(InitializeUnit,eventComponent));
            }
        }

        public void Remove(IEntity entity)
        {
            Destroy(_entities[entity]);
            _entities.Remove(entity);
        }

        private void InitializeUnit(UnitCreatedEvent created)
        {
            created.Unit.Events.Subscribe(new ActionHandler<UnitMovedEvent>(UpdateUnit));
                
            _entities[created.Unit] = Instantiate(_prefab);
            _prefab.transform.position = created.Unit.Transform.Position;
        }

        private void UpdateUnit(UnitMovedEvent movedEvent)
        {
            MoveUnitCommand command = movedEvent.Command;
            _movements.Add(new Movement(_entities[command.Unit].transform.position,command.Unit.Transform.Position,command.Unit));
        }

        private void Update()
        {
            foreach (Movement movement in _movements)
            {
                _entities[movement.Entity].transform.position = Vector3.Lerp(movement.From,movement.To,movement.Bomb += _speed * Time.deltaTime);
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