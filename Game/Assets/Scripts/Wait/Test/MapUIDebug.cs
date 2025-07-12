using BuildingsTestGame;
using TDS.Worlds;
using UnityEngine;
using Terrain = TDS.Worlds.Terrain;

namespace TDS.Entities
{
    public class MapUIDebug : MonoBehaviour
    {
        [SerializeField] private float _pointsSize = 0.3f;
        [SerializeField] private float _gapSize = 0.1f;
        public IMap Map { get; set; }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying || Map == null) return;
            
            foreach (var terrain in Map.Terrains)
            {
                Gizmos.color = terrain is IHaveColor c ? c.Color : Color.grey;
                DrawTerrain(terrain);
            }
        }
        
        private void DrawTerrain(ITerrain point)
        {
            if (point.Area is BoundsArea a)
            {
                Gizmos.DrawCube(a.Bounds.center, a.Bounds.size - Vector3.one * _gapSize);
            }

            if (point is BuildingTerrain t)
            {
                if (t.Unit != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(point.Area.Position, _pointsSize);
                }
            }
        }
    }
}