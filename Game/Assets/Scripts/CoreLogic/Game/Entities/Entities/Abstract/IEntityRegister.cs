using System;
using System.Collections.Generic;

namespace TDS.Entities
{
    public interface IEntityRegister : IEnumerable<IEntity>
    {
        IEnumerable<IEntity> Entities { get; }
        event Action OnEntityAdded;
        event Action OnEntityRemoved;

        void AddEntity(IEntity entity);
        void RemoveEntity(IEntity entity);
    }
}