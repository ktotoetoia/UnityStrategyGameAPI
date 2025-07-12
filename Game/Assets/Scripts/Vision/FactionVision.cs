using System.Collections.Generic;
using System.Linq;
using TDS.Entities;
using TDS.Factions;
using TDS.Worlds;

namespace TDS.VisionSystem
{
    public class FactionVision : IFactionVision
    {
        private readonly List<IEntity> _allEntities;
        private readonly List<IFactionUnit> _ownedUnits = new();
        private readonly List<IFactionUnit> _unownedUnits = new();

        public IEnumerable<IFactionUnit> OwnedUnits => _ownedUnits;
        public IEnumerable<IFactionUnit> UnownedUnits => _unownedUnits;
        public IEnumerable<IEntity> AllEntities => _allEntities;

        public FactionVision(IFaction faction, IEnumerable<IEntity> allEntities)
        {
            _allEntities = allEntities.ToList();

            foreach (var entity in _allEntities)
            {
                if (entity is IFactionUnit unit)
                {
                    if (unit.Faction == faction)
                    {
                        _ownedUnits.Add(unit);

                        continue;
                    }

                    _unownedUnits.Add(unit);
                }
            }
        }
    }
}