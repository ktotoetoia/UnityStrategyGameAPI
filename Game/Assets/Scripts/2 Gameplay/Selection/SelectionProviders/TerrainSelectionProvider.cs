using System;
using System.Linq;
using TDS.Maps;
using UnityEngine;

namespace TDS.SelectionSystem
{
    public class TerrainSelectionProvider : ISelectionProvider
    {
        public IMap Map { get; set; }
        public Func<ITerrain,bool> Allow { get; protected set; }
        
        public TerrainSelectionProvider(IMap map)
        {
            Map = map;
        }
        
        public ISelection<T> SelectAt<T>(Vector3 position) where T : class
        {
            ITerrain terrain = Map.GetTerrainsAt(position).FirstOrDefault(x => x is T);
            Selection<T> selection = new Selection<T>();

            if (terrain != null && (Allow == null || Allow(terrain)))
            {
                selection = new Selection<T>(terrain as T);
            }

            return selection;
        }

        public ISelection<T> SelectWithin<T>(Bounds bounds) where T : class
        {
            throw new NotImplementedException();
        }
    }
}