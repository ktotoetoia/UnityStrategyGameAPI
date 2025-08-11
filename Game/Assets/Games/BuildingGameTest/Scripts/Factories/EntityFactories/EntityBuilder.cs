using System;
using TDS;
using TDS.Entities;
using UnityEngine;

namespace BuildingsTestGame
{
    public class EntityBuilder<TEntity> : IBuilder<TEntity> where TEntity : Entity
    {
        private readonly IEntityRegister _entityRegister;
        private readonly IEventComponent _eventComponent;
        private readonly IPlacedOnTerrain _terrainComponent;
        private bool _isFinished;
        
        public TEntity Value { get; }

        public EntityBuilder(TEntity entity, IEntityRegister entityRegister)
        {
            Value = entity ?? throw new ArgumentNullException(nameof(entity));
            _entityRegister = entityRegister ?? throw new ArgumentNullException(nameof(entityRegister));

            if (!Value.TryGetComponent(out _eventComponent))
            {
                throw new InvalidOperationException("Entity is missing IEventComponent.");
            }

            if (!Value.TryGetComponent(out _terrainComponent))
            {
                throw new InvalidOperationException("Entity is missing IHaveTerrain.");
            }
        }
        
        public void FinishInitialization()
        {
            _entityRegister.AddEntity(Value);
            _eventComponent.Publish(new EntityInitializedEvent(Value, _terrainComponent.PlacedOn));
            _isFinished = true;
        }

        public void CancelInitialization()
        {
            _isFinished = true;
        }
        
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        ~EntityBuilder()
        {
            if (!_isFinished)
            {
                Debug.LogError($"Entity {Value} was not initialized or canceled before builder disposal.");
            }
        }
#endif
    }
}