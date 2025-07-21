using TDS.Entities;

namespace TDS.Worlds
{
    public class World : IWorld
    {
        public IEntityRegister EntityRegister { get; }
        public IMap Map { get; }
        
        public World(IMap map) : this(new EntityRegister(), map)
        {
        }

        public World(IEntityRegister entityRegister, IMap map)
        {
            EntityRegister = entityRegister;
            Map = map;
        }
    }
}