using BuildingsTestGame;
using TDS.SelectionSystem;
using UnityEngine;

namespace TDS
{
    public class BuildingMonoBehaviour : MonoBehaviour, ISelectable
    {
        public IBuilding Building { get; set; }
        
        public bool TryGetObject<T>(out T obj)
        {
            Debug.Log("sigma");
            
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