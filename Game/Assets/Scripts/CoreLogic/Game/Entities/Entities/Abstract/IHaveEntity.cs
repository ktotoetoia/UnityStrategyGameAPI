using TDS.Entities;

namespace TDS
{
    public interface IHaveEntity
    {
        IEntity Entity { get; }
    }
}