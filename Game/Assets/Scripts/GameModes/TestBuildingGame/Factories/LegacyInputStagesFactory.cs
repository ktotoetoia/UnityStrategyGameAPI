using System.Collections.Generic;
using TDS;
using TDS.Commands;
using TDS.Events;
using TDS.SelectionSystem;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class LegacyInputStagesFactory : IFactory<(GameStage,GameStage,GameStage),IWorld>
    {
        public (GameStage,GameStage,GameStage) Create(IWorld world)
        {
            GameStage assignStage = new GameStage();
            GameStage buildStage = new GameStage();
            GameStage eventStage = new GameStage();
            CommandSequencer assignSeq = new CommandSequencer();
            assignStage.CommandSequencer = assignSeq;
            assignSeq.HandlersList.Add(new EndTurnCommandHandler());
            assignSeq.HandlersList.Add(new CreateUnitCommandHandler());
            assignSeq.HandlersList.Add(new MoveUnitCommandHandler());
            assignSeq.HandlersList.Add(new SelectorCommandHandler());
            
            CommandSequencer buildSeq = new CommandSequencer();
            buildStage.CommandSequencer = buildSeq;
            buildSeq.HandlersList.Add(new EndTurnCommandHandler());
            buildSeq.HandlersList.Add(new SelectorCommandHandler());

            CommandSequencer eventSeq = new CommandSequencer();
            eventStage.CommandSequencer = eventSeq;
            eventSeq.HandlersList.Add(new EndTurnCommandHandler());
            
            LegacyInputBuildingGameContext context = new LegacyInputBuildingGameContext()
            {
                AssignStage = assignStage,
                BuildStage = buildStage,
                EventStage = eventStage,
                World = world,
                Selector = new TerrainSelector(world.Map),
                Pathfinder = new MapPathfinder(world.Map),
            };
            
            assignStage.InputHandler = new AssignStageLegacyInput(context);
            buildStage.InputHandler = new BuildStageLegacyInput(context);
            eventStage.InputHandler = new BuildStageLegacyInput(context);

            return (assignStage,buildStage,eventStage);
        }
    }
}