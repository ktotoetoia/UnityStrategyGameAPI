using TDS.Entities;

namespace BuildingsTestGame
{
    public interface IProductionBuilding : IBuilding
    {
        void AddToQueue(IEntity unit);
    }
}