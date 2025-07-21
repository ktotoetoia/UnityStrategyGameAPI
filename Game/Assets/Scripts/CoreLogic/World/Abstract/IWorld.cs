using TDS.Entities;

namespace TDS.Worlds
{
    public interface IWorld
    {
        IEntityRegister EntityRegister { get; }
        IMap Map { get; }
    }
}