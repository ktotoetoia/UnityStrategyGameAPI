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

        private Dictionary<IUnit, GameObject> _units = new();
        private ISelection<ITerrain> currentSelection;
        private IPath<ITerrain> _path;
        private IUnit _currentUnit;

        public ICommandQueue Queue { get; set; }

        // How fast to move in units per second
        [SerializeField] private float _moveSpeed = 2f;

        private Vector3 _currentTargetPos;
        private bool _isMoving = false;

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
                _currentTargetPos = _path.Nodes[1].Value.Area.Position;
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