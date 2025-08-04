using System.Collections.Generic;

namespace TDS.Entities
{
    public interface IEntityRegister : IEnumerable<IEntity>
    {
        IEnumerable<IEntity> Entities { get; }

        void AddEntity(IEntity entity);
        void RemoveEntity(IEntity entity);
    }
    
    public interface IEntityRegister<TEntity> : IEnumerable<TEntity> where  TEntity : IEntity
    {
        IEnumerable<TEntity> Entities { get; }

        void AddEntity(TEntity entity);
        void RemoveEntity(TEntity entity);
    }
}