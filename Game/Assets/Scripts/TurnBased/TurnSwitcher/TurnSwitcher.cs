using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TDS.TurnSystem
{
    public class TurnSwitcher : ITurnSwitcher
    {
        private readonly List<ITurnUser> _users;
        private Task _currentTurnTask;
        private int _currentIndex = 0;

        public Func<bool> ShouldAdvanceTurn { get; set; }
        
        public IEnumerable<ITurnUser> Users => _users;

        public ITurnUser CurrentUser => _users.Count == 0 ? null : _users[_currentIndex];
        
        public TurnSwitcher(IEnumerable<ITurnUser> users, Func<bool> trigger)
        {
            _users = users.ToList();
            ShouldAdvanceTurn = trigger;
            _currentTurnTask = Task.CompletedTask;
        }

        public TurnSwitcher(IEnumerable<ITurnUser> users) : this(users, () => true)
        {
            
        }

        public void Update()
        {
            if (_currentTurnTask.IsCompleted && ShouldAdvanceTurn())
            {
                _currentTurnTask = RunTurn();
            }
        }

        private async Task RunTurn()
        {
            var user = CurrentUser;
            await user.ExecuteTurnAsync();

            _currentIndex = (_currentIndex + 1) % _users.Count;
        }
    }
}