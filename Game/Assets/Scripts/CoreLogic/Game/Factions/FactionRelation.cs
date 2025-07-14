using System;

namespace TDS.Factions
{
    [Serializable]
    public struct FactionRelation
    {
        public Relation Relation;
        public IFaction Faction;

        public FactionRelation(IFaction faction, Relation relation)
        {
            Faction = faction;
            Relation = relation;
        }
    }
}