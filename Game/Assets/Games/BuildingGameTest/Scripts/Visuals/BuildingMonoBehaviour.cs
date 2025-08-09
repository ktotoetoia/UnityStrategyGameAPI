using TDS.SelectionSystem;
using UnityEngine;

namespace TDS
{
    public class BuildingMonoBehaviour : MonoBehaviour, ISelectable
    {
        public IDestroyable Building { get; set; }
        
        public bool TryGetObject<T>(out T obj)
        {
            if (Building is T building)
            {
                obj = building;
                
                return true;
            }

            obj = default;
            
            return false;
        }
    }
}