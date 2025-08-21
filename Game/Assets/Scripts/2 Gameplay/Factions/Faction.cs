using TDS.Events;
using UnityEngine;

namespace TDS.Factions
{
    public class Faction : IFaction
    {
        public string Name { get; set; }
        public Color Color { get; set; }
        
        public Faction(string name, Color color)
        {
            Name = name;
            Color = color;
        }
    }
}