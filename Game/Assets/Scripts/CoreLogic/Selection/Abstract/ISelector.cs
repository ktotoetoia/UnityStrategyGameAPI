using UnityEngine;

namespace TDS.SelectionSystem
{
    public interface ISelector : IHaveSelection
    {
        event System.Action OnSelected;

        void UpdateSelection(Vector3 position);
        void UpdateSelection(Bounds bounds);
        
        ISelection<T> GetSelection<T>(Vector3 position) where T : class;
        ISelection<T> GetSelection<T>(Bounds bounds)where T : class;
        
        ISelection<T> SelectionOfType<T>()where T : class;
    }
}