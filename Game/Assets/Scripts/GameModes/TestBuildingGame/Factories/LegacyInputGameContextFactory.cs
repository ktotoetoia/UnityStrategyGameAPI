using System.Collections.Generic;
using TDS;
using TDS.Commands;
using TDS.SelectionSystem;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class LegacyInputGameContextFactory : IFactory<(GameStage,GameStage,GameStage),IWorld>
    {
        public (GameStage,GameStage,GameStage) Create(IWorld world)
        {
            GameStage assignStage = new GameStage();
            GameStage buildStage = new GameStage();
            GameStage eventStage = new GameStage();
            
            assignStage.CommandQueue = new CommandQueue(new CompositeCommandHandler(new List<ICommandHandler>
            {
                new EndTurnCommandHandler(),
                new CreateUnitCommandHandler(),
                new MoveUnitCommandHandler(),
                new SelectorCommandHandler(),
            }));
            buildStage.CommandQueue = new CommandQueue(new CompositeCommandHandler(new List<ICommandHandler>
            {
                new EndTurnCommandHandler(),
                new SelectorCommandHandler(),
            }));
            eventStage.CommandQueue = new CommandQueue(new CompositeCommandHandler(new List<ICommandHandler>
            {
                new EndTurnCommandHandler(),
            }));
            
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