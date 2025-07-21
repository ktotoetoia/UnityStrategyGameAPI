using System;
using System.Collections;
using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public record EndTurnCommand(ITurnUserManual TurnUser) : ICommand;
}