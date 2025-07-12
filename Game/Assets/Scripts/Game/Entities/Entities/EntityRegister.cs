using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace TDS.Entities
{
    public class EntityRegister : IEntityRegister
    {
        private readonly List<IEntity> _entities = new();

        public event Action OnEntityAdded;
        public event Action OnEntityRemoved;

        public IEnumerable<IEntity> Entities
        {
            get
            {
                foreach (var entity in _entities) yield return entity;
            }
        }

        public void AddEntity(IEntity entity)
        {
            if (_entities.Contains(entity))
            {
                Debug.LogWarning("Entity is already added to the register");

                return;
            }

            _entities.Add(entity);
            OnEntityAdded?.Invoke();
        }

        public void RemoveEntity(IEntity entity)
        {
            if (!_entities.Contains(entity))
            {
                Debug.LogWarning("Entity is not present in the register");

                return;
            }

            _entities.Remove(entity);
            OnEntityRemoved?.Invoke();
        }

        public IEnumerator<IEntity> GetEnumerator()
        {
            return _entities.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return _entities.GetEnumerator();
        }
    }
}