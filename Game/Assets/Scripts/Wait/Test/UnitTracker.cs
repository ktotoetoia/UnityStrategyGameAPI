using System.Collections.Generic;
using BuildingsTestGame;
using TDS.Commands;
using TDS.Entities;
using TDS.Events;
using UnityEngine;

namespace TDS
{
    public class UnitTracker : MonoBehaviour
    {
        [SerializeField] private GameObject _prefab;
        private Dictionary<IEntity, GameObject> _entities = new Dictionary<IEntity, GameObject>();
        private BuildingGame _game;

        public BuildingGame Game
        {
            get
            {
                return _game;
            }
            set
            {
                _game  = value;

                _game.EntityRegisterEvents.Subscribe(new TypedActionHandler<EntityAddedEvent>(x => Add(x.Value)));
                _game.EntityRegisterEvents.Subscribe(new TypedActionHandler<EntityRemovedEvent>(x => Remove(x.Value)));
            }
        }
        
        private void Add(IEntity entity)
        {
            if (entity .TryGetComponent(out IEventComponent eventComponent))
            {
                eventComponent.Subscribe(new TypedActionHandler<UnitCommandEvent>(x => UpdateUnit(x.Value)));
                
                _entities[entity] = Instantiate(_prefab);
                _prefab.transform.position = entity.Transform.Position;
            }
        }

        private void Remove(IEntity entity)
        {
            Destroy(_entities[entity]) ;
            _entities.Remove(entity);
        }

        private void UpdateUnit(CommandStatus status)
        {
                Debug.Log(status.Command.GetType().Name);
                
            
            if (status.Command is MoveUnitCommand move)
            {
                Debug.Log(move.Unit.Transform.Position);
                _entities[move.Unit].transform.position = move.Unit.Transform.Position;
            }
        }
    }
}