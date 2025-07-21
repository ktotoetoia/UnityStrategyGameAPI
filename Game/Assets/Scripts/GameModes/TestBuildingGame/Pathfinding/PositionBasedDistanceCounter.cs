using System.Collections.Generic;
using TDS.Graphs;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class PositionBasedDistanceCounter : IDistanceCounter
    {
        public float GetDistance<T>(IEnumerable<INode<T>> path) where T : ITerrain
        {
            float distance = 0;
            INode<T> startNode = null;
            
            foreach (INode<T> node in path)
            {
                if (startNode == null)
                {
                    startNode = node;
                    
                    continue;
                }
                
                distance += Vector2.Distance(node.Value.Area.Position, startNode.Value.Area.Position);
            }
            
            return distance;
        }
    }
}