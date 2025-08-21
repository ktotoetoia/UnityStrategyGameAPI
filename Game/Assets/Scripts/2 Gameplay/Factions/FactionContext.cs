using System;
using System.Collections.Generic;
using System.Linq;
using BuildingsTestGame;
using TDS.Entities;
using TDS.Events;
using TDS.Handlers;

namespace TDS.Factions
{
    public class FactionContext : IFactionContext
    {
        private readonly Dictionary<IEntity,IFactionComponent> _entities;

        public IEnumerable<IEntity> Entities => from keyValuePair in _entities where keyValuePair.Value.Faction == Faction select keyValuePair.Key;
        public IFaction Faction { get; }
        
        public FactionContext(IFaction faction)
        {
            Faction = faction;
            _entities = new Dictionary<IEntity,IFactionComponent>();
        }

        public void Add(IEntity entity)
        {
            if (!entity.TryGetComponent(out IFactionComponent factionComponent) || factionComponent .Faction != Faction)
            {
                throw new ArgumentException();
            }
            
            _entities.Add(entity, factionComponent);
        }

        public void Remove(IEntity entity)
        {
            _entities.Remove(entity);
        }
    }
}