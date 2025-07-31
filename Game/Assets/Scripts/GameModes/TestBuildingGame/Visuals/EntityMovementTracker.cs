using System.Collections.Generic;
using BuildingsTestGame;
using TDS.Commands;
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
                eventComponent.Subscribe(new ActionHandler<ICommandEvent<MoveUnitCommand>>(UpdateUnit));
                
                _entities[entity] = Instantiate(_prefab);
                _prefab.transform.position = entity.Transform.Position;
            }
        }

        public void Remove(IEntity entity)
        {
            Destroy(_entities[entity]);
            _entities.Remove(entity);
        }

        private void UpdateUnit(ICommandEvent<MoveUnitCommand> commandEvent)
        {
            MoveUnitCommand command = commandEvent.Command;
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