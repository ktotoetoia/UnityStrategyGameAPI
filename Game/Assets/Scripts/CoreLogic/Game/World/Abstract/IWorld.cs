using System.Collections.Generic;
using TDS.Entities;
using TDS.Factions;

namespace TDS.Worlds
{
    public interface IWorld
    {
        IEntityRegister EntityRegister { get; }
        IMap Map { get; }
    }
}