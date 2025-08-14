using TDS.SelectionSystem;
using UnityEngine;

namespace TDS
{
    public class SelectorInput : MonoBehaviour
    {
        private ISelector _selector;

        private void Awake()
        {
            _selector = GetComponent<ISelector>();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector2 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                _selector.UpdateSelectionAt(clickPosition);
            }
        }
    }
}