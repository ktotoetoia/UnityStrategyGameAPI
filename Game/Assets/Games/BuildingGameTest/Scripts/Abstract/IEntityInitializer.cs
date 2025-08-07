using TDS.Entities;

namespace BuildingsTestGame
{
    public interface IEntityInitializer
    {
        void Initialize(IEntity entity);
    }
}