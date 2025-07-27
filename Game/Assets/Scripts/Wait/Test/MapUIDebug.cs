﻿using BuildingsTestGame;
using TDS.Maps;
using UnityEngine;

namespace TDS.Entities
{
    public class MapUIDebug : MonoBehaviour
    {
        [SerializeField] private float _gapSize = 0.1f;
        [SerializeField] float _pointsSize;
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
                    Gizmos.DrawSphere(point.Area.Position - _pointsSize * Vector3.right, _pointsSize);
                }

                if (t.Building != null)
                {
                    Gizmos.color = Color.green;
                    Gizmos.DrawCube(t.Area.Position + _pointsSize * Vector3.right, new Vector3(_pointsSize, _pointsSize * 2));
                }
            }
        }
    }
}