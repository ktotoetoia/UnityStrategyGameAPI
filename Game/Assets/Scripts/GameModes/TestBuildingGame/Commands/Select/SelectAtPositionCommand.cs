using TDS.Commands;
using TDS.Events;
using TDS.SelectionSystem;
using UnityEngine;

namespace BuildingsTestGame
{
    public class SelectAtPositionCommand : Command
    {
        public ISelector Selector { get; init; }
        public Vector3 Position { get; init; }
        
        public SelectAtPositionCommand(ISelector Selector, Vector3 Position)
        {
            this.Selector = Selector;
            this.Position = Position;
        }
    }
}