using System.Collections.Generic;
using System.Linq;
using TDS.Commands;
using TDS.Entities;
using TDS.SelectionSystem;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class UIDebugHandler : MonoBehaviour
    {
        [SerializeField] GameObject _unitPrefab;
        [SerializeField] private float _moveSpeed = 2f;
        private Dictionary<IUnit, GameObject> _units = new();
        private ISelection<ITerrain> currentSelection;
        private IPath<ITerrain> _path;
        private IUnit _currentUnit;

        public ICommandQueue Queue { get; set; }
        private bool _isMoving;

        private void Update()
        {
            if (Queue == null)
                return;

            if (_isMoving)
            {
                UpdateMovement();
                return;
            }
            
            if (Queue.Current is SelectAtPositionCommand pos)
            {
                currentSelection = pos.Selector.SelectionOfType<ITerrain>();
                Queue.CompleteCurrent();
            }
            else if (Queue.Current is CreateUnitCommand create)
            {
                GameObject ob = Instantiate(_unitPrefab);
                _units[create.CreatedUnit] = ob;
                
                ob.transform.position = create.Building.Terrain.Area.Position;
                Queue.CompleteCurrent();
            }
            else if (Queue.Current is MoveUnitCommand move)
            {
                _path = move.Path;
                _currentUnit = move.Unit;

                if (_path.Nodes.Count < 2)
                {
                    Queue.CompleteCurrent();
                    return;
                }

                _isMoving = true;
            }
        }

        private float t = 0;

        private void UpdateMovement()
        {
            _units[_currentUnit].transform.position = Vector3.Lerp(_path.Start.Value.Area.Position,_path.End.Value.Area.Position,t += _moveSpeed * Time.deltaTime);

            if (_units[_currentUnit].transform.position == _path.End.Value.Area.Position)
            {
                _isMoving = false;
                _path = null;
                _currentUnit = null;
                t = 0;   
                Queue.CompleteCurrent();
            }
        }

        private void OnDrawGizmos()
        {
            if (currentSelection != null)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawSphere(currentSelection.First.Area.Position, 0.2f);
            }
        }
    }
}