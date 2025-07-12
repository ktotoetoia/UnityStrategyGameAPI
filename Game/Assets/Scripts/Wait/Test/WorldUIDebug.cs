using TDS.Worlds;
using UnityEditor;
using UnityEngine;

namespace TDS.Entities
{
    public class WorldUIDebug : MonoBehaviour
    {
        [SerializeField] private int _fontSize = 20;
        [SerializeField] private float _pointsSize = 0.3f;

        public IWorld World { get; set; }

        private void OnDrawGizmos()
        {
            if (!Application.isPlaying || World == null) return;

            foreach (var terrain in World.Map.Terrains)
            {
                Gizmos.color = Color.grey;
                DrawTerrain(terrain);
            }

            foreach (var entity in World.EntityRegister)
            {
                var position = entity.Transform.Position;
                var style = new GUIStyle
                {
                    alignment = TextAnchor.MiddleCenter,
                    normal = new GUIStyleState { textColor = Color.white },
                    fontSize = _fontSize
                };

                var text = entity.Name;

                if (entity is IFactionUnit unit)
                    text = (unit.Faction == null ? "No Faction" : unit.Faction.Name) + ": " + entity.Name;

                Handles.Label(position + Vector3.up * 1.5f, text, style);
                Gizmos.DrawCube(position, Vector3.one * 0.1f);
            }
        }

        private void DrawTerrain(ITerrain point)
        {
            if (point.Area is BoundsArea a)
            {
                Gizmos.DrawCube(a.Bounds.center, a.Bounds.size);

                return;
            }

            Gizmos.DrawSphere(point.Area.Position, _pointsSize);
        }
    }
}