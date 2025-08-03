using TDS.Entities;

namespace TDS
{
    public interface IEntityObserver
    {
        public void Add(IEntity entity);
        public void Remove(IEntity entity);
    }
}