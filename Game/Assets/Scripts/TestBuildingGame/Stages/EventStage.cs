using System;
using System.Threading.Tasks;
using TDS.TurnSystem;
using UnityEngine;

namespace BuildingsTestGame
{
    public class EventStage : ITurnUser
    {
        public ValueTask ExecuteTurnAsync()
        {
            return new ValueTask(Task.CompletedTask);
        }
    }
}