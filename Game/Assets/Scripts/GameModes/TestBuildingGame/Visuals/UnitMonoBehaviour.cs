using BuildingsTestGame;
using TDS.SelectionSystem;
using UnityEngine;

namespace TDS
{
    public class UnitMonoBehaviour : MonoBehaviour, ISelectable
    {
        public IUnit Unit { get; set; }
        
        public bool TryGetObject<T>(out T obj)
        {
            if (Unit is T tUnit)
            {
                obj = tUnit;
                
                return true;
            }

            obj = default;
            
            return false;
        }
    }
}