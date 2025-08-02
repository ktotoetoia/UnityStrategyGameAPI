using TDS.SelectionSystem;
using UnityEngine;

namespace TDS
{
    public class UnitUUU : MonoBehaviour, ISelectable
    {
        public bool TryGetObject<T>(out T obj)
        {
            Debug.Log("TryGetObject");
            
            throw new System.NotImplementedException();
        }
    }
}