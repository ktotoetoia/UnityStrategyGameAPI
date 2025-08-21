using System;
using System.Collections;
using System.Collections.Generic;
using TDS.Handlers;
using UnityEngine;

namespace TDS.Entities
{
    public class EntityRegistry : IEntityRegistry
    {
        private readonly List<IEntity> _entities = new();

        public event Action<IEntity> OnEntityAdded;
        public event Action<IEntity> OnEntityRemoved;

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
            entity.EntityRegistry = this;
            OnEntityAdded?.Invoke(entity);
        }

        public void RemoveEntity(IEntity entity)
        {
            if (!_entities.Contains(entity))
            {
                Debug.LogWarning("Entity is not present in the register");

                return;
            }

            _entities.Remove(entity);
            entity.EntityRegistry = null;
            OnEntityRemoved?.Invoke(entity);
        }

        public bool Contains(IEntity entity)
        {
            return _entities.Contains(entity);
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