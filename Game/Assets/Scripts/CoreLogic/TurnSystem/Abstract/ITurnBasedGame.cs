﻿using TDS.Worlds;

namespace TDS.TurnSystem
{
    public interface ITurnBasedGame
    {
        public IWorld World { get; }
        public ITurnSwitcher TurnSwitcher { get; }
    }
}