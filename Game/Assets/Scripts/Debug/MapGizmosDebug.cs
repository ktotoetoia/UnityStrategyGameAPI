using BuildingsTestGame;
using TDS.Maps;
using UnityEngine;

namespace TDS.Entities
{
    public class MapGizmosDebug : MonoBehaviour
    {
        [SerializeField] private bool _showTerrainArea;
        [SerializeField] private bool _showUnits;
        [SerializeField] private bool _showBuildings;
        [SerializeField] private float _gapSize = 0.1f;
        [SerializeField] private float _pointsSize;
        
        public IMap Map { get; set; }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying || Map == null ) return;
            
            foreach (var terrain in Map.Terrains)
            {
                Gizmos.color = terrain is IHaveColor c ? c.Color : Color.grey;
                DrawTerrain(terrain);
            }
        }
        
        private void DrawTerrain(ITerrain point)
        {
            if (_showTerrainArea && point.TerrainArea is BoundsArea a)
            {
                Gizmos.DrawCube(a.Bounds.center, a.Bounds.size - Vector3.one * _gapSize);
            }
            
            if (point is GameTerrain t)
            {
                if (_showUnits && t.GameTerrainComponent.Unit != null)
                {
                    Gizmos.color = Color.red;
                    Gizmos.DrawSphere(point.Transform.Position - _pointsSize * Vector3.right, _pointsSize);
                }

                if (_showBuildings && t.GameTerrainComponent.Building != null)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawCube(t.Transform.Position + _pointsSize * Vector3.right, new Vector3(_pointsSize, _pointsSize * 2));
                }
            }
        }
    }
}