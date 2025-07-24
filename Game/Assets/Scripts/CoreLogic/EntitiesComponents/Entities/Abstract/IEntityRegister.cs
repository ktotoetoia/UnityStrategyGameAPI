using System;
using System.Collections.Generic;

namespace TDS.Entities
{
    public interface IEntityRegister : IEnumerable<IEntity>
    {
        IEnumerable<IEntity> Entities { get; }

        void AddEntity(IEntity entity);
        void RemoveEntity(IEntity entity);
    }
}