using System.Collections.Generic;
using TDS.Entities;
using TDS.SelectionSystem;
using UnityEngine;

namespace TDS
{
    public class UnitMonoBehaviour : MonoBehaviour, ISelectable
    {
        [SerializeField] private float _speed;
        private List<Vector3> _positions = new List<Vector3>();
        private Vector3 _lastPosition;
        public IEntity Unit { get; set; }
        private float _t;
        
        public bool TryGetObject<T>(out T obj)
        {
            if (Unit is T unit)
            {
                obj = unit;
                
                return true;
            }

            obj = default;
            
            return false;
        }

        public void MoveTo(Vector3 position)
        {
            _positions.Add(position);
        }

        private void Update()
        {
            if (_positions.Count == 0)
            {
                return;
            }

            transform.position = Vector3.Lerp(_lastPosition,_positions[0],_t += _speed * Time.deltaTime);
            if (transform.position == _positions[0])
            {
                _lastPosition =  _positions[0];
                _positions.RemoveAt(0);
                _t = 0;
            }
        }
    }
}