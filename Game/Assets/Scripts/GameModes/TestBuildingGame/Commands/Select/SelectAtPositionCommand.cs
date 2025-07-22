using TDS.Commands;
using TDS.SelectionSystem;
using UnityEngine;

namespace BuildingsTestGame
{
    public class SelectAtPositionCommand : Command
    {
        public SelectAtPositionCommand(ISelector Selector, Vector3 Position)
        {
            this.Selector = Selector;
            this.Position = Position;
        }

        public ISelector Selector { get; init; }
        public Vector3 Position { get; init; }

        public void Deconstruct(out ISelector Selector, out Vector3 Position)
        {
            Selector = this.Selector;
            Position = this.Position;
        }
    }
}