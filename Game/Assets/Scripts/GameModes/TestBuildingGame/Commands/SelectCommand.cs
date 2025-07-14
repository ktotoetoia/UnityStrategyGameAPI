using TDS.Commands;
using UnityEngine;

namespace BuildingsTestGame
{
    public class SelectCommand : ICommand
    {
        public Vector3 Position { get; }

        public SelectCommand(Vector3 position)
        {
            Position = position;
        }
    }
}