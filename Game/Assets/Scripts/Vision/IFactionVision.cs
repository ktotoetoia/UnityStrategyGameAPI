using System.Collections.Generic;
using TDS.Entities;
using TDS.Worlds;

namespace TDS.VisionSystem
{
    public interface IFactionVision
    {
        public IEnumerable<IFactionUnit> OwnedUnits { get; }
        public IEnumerable<IFactionUnit> UnownedUnits { get; }
        public IEnumerable<IEntity> AllEntities { get; }
    }
}