using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDS.Entities;
using TDS.Factions;
using TDS.SelectionSystem;
using TDS.Systems;
using UnityEngine;
using TDS.VisionSystem;
using TDS.Worlds;

namespace TDS.TurnSystem
{
    public class PlayerTurnLogic : ITurnUser, ISystemUser, IUpdatable
    {
        private readonly IFaction _faction;
        private readonly IVision _vision;
        private TaskCompletionSource<bool> _tcs;
        private Vector3 _selectedPosition;
        private UnitCreationSystem _unitCreationSystem;
        private FightSystem _fightSystem;
        private TurnBasedMovementSystem _movementSystem;
        
        public ISelector Selector { get; private set; }
        
        public PlayerTurnLogic(IFaction faction,IWorld world)
        {
            _faction = faction;
            Selector = new AnyEntitySelector(world);
            _vision = new Vision(world);
        }

        public ValueTask ExecuteTurnAsync()
        {
            _tcs = new TaskCompletionSource<bool>(TaskCreationOptions.RunContinuationsAsynchronously);
            Debug.Log($"{_faction.Name}'s turn started...");
            
            var vision = _vision.GetVision(_faction);

            foreach (ITurnBasedFactionUnit unit in vision.OwnedUnits.OfType<ITurnBasedFactionUnit>())
            {
                unit.OnTurnStart();
            }
            
            return new ValueTask(_tcs.Task);
        }

        public void Update()
        {
            if (_tcs?.Task.IsCompleted ?? true)
            {
                return;
            }

            var vision = _vision.GetVision(_faction);
            
            if (Input.GetMouseButtonDown(0))
            {
                Selector.UpdateSelection(GetMousePosition());
                _selectedPosition = GetMousePosition();
            }

            if (Input.GetKeyDown(KeyCode.C) && _unitCreationSystem != null)
            {
                _unitCreationSystem.CreateUnit(_faction, _selectedPosition);
            }

            if (Input.GetMouseButtonDown(1)&& _movementSystem != null)
            {
                _movementSystem.Move(Selector.Selection.First.Object as IFactionUnit, GetMousePosition());
            }

            if (Input.GetKeyDown(KeyCode.A) && _fightSystem != null)
            {
                IFactionUnit unit = GetClosest(_vision.GetVision(_faction).OwnedUnits ,_selectedPosition);
                
                _fightSystem.Fight(unit, GetClosest(_vision.GetVision(_faction).UnownedUnits,GetMousePosition()));
            }

            if (Input.GetKeyDown(KeyCode.Space))
            {
                foreach (ITurnBasedFactionUnit unit  in vision.OwnedUnits.OfType<ITurnBasedFactionUnit>())
                {
                    unit.OnTurnEnd();
                }
                
                _tcs.SetResult(true);
            }
        }

        private IFactionUnit GetClosest(IEnumerable<IFactionUnit> units, Vector3 position)
        {
            IFactionUnit closest = null;
            float closestDistance = 2;

            foreach (var unit in units)
            {
                if (Vector3.Distance(unit.Transform.Position, position) < closestDistance)
                {
                    closest = unit;
                }
            }

            return closest;
        }

        private Vector3 GetMousePosition()
        {
            var mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            mousePos.z = 0;

            return mousePos;
        }

        public IEnumerable<Type> GetRequiredSystems()
        {
            return new[] { typeof(FightSystem), typeof(TurnBasedMovementSystem), typeof(UnitCreationSystem) };
        }

        public void Inject(IEnumerable<ISystem> systems)
        {
            _fightSystem = systems.OfType<FightSystem>().FirstOrDefault();
            _movementSystem = systems.OfType<TurnBasedMovementSystem>().FirstOrDefault();
            _unitCreationSystem = systems.OfType<UnitCreationSystem>().FirstOrDefault();
        }
    }
}