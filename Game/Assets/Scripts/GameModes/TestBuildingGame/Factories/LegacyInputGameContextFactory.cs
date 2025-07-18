using TDS;
using TDS.Pathfinding;
using TDS.SelectionSystem;
using TDS.TurnSystem;
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
                Pathfinder = new DijkstraAlgorithm()
            };
            
            (context.AssignStage as GameStage).CommandHandler = new AssignStageCommandHandler();
            (context.AssignStage as GameStage).InputHandler = new AssignStageLegacyInput(context);
            (context.BuildStage as GameStage).CommandHandler = new BuildStageCommandHandler();
            (context.BuildStage as GameStage).InputHandler = new BuildStageLegacyInput(context);
            (context.EventStage as GameStage).CommandHandler = new EventStageCommandHandler(context);
            (context.EventStage as GameStage).InputHandler = new BuildStageLegacyInput(context);
            
            return context;
        }
    }
}