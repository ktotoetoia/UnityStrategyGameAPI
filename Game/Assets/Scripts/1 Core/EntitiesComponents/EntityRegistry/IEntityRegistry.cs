using System.Collections.Generic;

namespace TDS.Entities
{
    public interface IEntityRegistry : IEnumerable<IEntity>
    {
        IEnumerable<IEntity> Entities { get; }

        void AddEntity(IEntity entity);
        void RemoveEntity(IEntity entity);
        
        bool Contains(IEntity entity);
    }
}