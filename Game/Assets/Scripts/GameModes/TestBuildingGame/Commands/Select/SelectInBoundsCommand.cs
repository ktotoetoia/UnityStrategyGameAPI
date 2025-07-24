using TDS.Events;
using TDS.SelectionSystem;
using UnityEngine;

namespace BuildingsTestGame
{
    public class SelectInBoundsCommand : IEvent
    {
        public ISelector Selector { get; init; }
        public Bounds Bounds { get; init; }
        
        public SelectInBoundsCommand(ISelector Selector, Bounds Bounds)
        {
            this.Selector = Selector;
            this.Bounds = Bounds;
        }
    }
}