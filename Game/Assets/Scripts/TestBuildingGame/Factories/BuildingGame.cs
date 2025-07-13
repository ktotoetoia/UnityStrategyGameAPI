using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TDS.Commands;
using TDS.TurnSystem;
using TDS.Worlds;
using UnityEngine;

namespace BuildingsTestGame
{
    public class BuildingGame : ITurnBasedGame
    {
        public IWorld World { get; }
        public ITurnSwitcher TurnSwitcher { get; }
        public GameStage AssignStage { get; }
        public GameStage BuildStage { get; }
        public GameStage EventStage { get; }
        public GameStage CurrentStage => TurnSwitcher.CurrentUser as GameStage;
        
        public BuildingGame(IWorld world)
        {
            World = world;
            
            var assignCommands = new CommandListener(new List<ICommandListener>()
            {
                new ActionCommandListener<EndTurnCommand>(x => Debug.Log("End Turn")),
                new ActionCommandListener<SelectCommand>(x => Debug.Log("selected"))
            });

            var buildCommands = new CommandListener(new List<ICommandListener>()
            {
                new ActionCommandListener<EndTurnCommand>(x => Debug.Log("End Turn")),
                new ActionCommandListener<SelectCommand>(x => Debug.Log("selected"))
            });
            
            AssignStage = new GameStage(assignCommands);
            BuildStage = new GameStage(buildCommands);
            EventStage = new GameStage(buildCommands);
            
            TurnSwitcher = new TurnSwitcher(new ITurnUser[] {AssignStage, BuildStage, EventStage});
        }
        
        public void Update()
        {
            TurnSwitcher.Update();
        }
    }
}