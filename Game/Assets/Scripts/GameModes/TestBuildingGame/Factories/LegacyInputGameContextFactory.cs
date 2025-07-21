using System.Collections.Generic;
using TDS;
using TDS.Commands;
using TDS.SelectionSystem;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class LegacyInputGameContextFactory : IFactory<LegacyInputBuildingGameContext,IWorld>
    {
        public LegacyInputBuildingGameContext Create(IWorld world)
        {
            LegacyInputBuildingGameContext context = new LegacyInputBuildingGameContext()
            {
                World = world,
                AssignStage = new GameStage(),
                BuildStage = new GameStage(),
                EventStage = new GameStage(),
                Selector = new TerrainSelector(world.Map),
                Pathfinder = new MapPathfinder(world.Map)
            };
            
            (context.AssignStage as GameStage).CommandHandler = new CompositeCommandHandler(new List<ICommandHandler>
            {
                new EndTurnCommandHandler(),
                new CreateUnitCommandHandler(),
                new MoveUnitCommandHandler(),
            });
            (context.BuildStage as GameStage).CommandHandler = new CompositeCommandHandler(new List<ICommandHandler>
            {
                new EndTurnCommandHandler(),
            });
            (context.EventStage as GameStage).CommandHandler = new CompositeCommandHandler(new List<ICommandHandler>
            {
                new EndTurnCommandHandler(),
            });
            
            (context.AssignStage as GameStage).InputHandler = new AssignStageLegacyInput(context);
            (context.BuildStage as GameStage).InputHandler = new BuildStageLegacyInput(context);
            (context.EventStage as GameStage).InputHandler = new BuildStageLegacyInput(context);

            return context;
        }
    }
}