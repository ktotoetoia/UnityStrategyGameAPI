using System.Collections.Generic;
using TDS;
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
            assignStage.EventBus = new EventBus();
            assignStage.EventBus.Subscribe(new EndTurnCommandHandler());
            assignStage.EventBus.Subscribe(new CreateUnitCommandHandler());
            assignStage.EventBus.Subscribe(new MoveUnitCommandHandler());
            assignStage.EventBus.Subscribe(new SelectorCommandHandler());
            
            buildStage.EventBus = new EventBus();
            buildStage.EventBus.Subscribe(new EndTurnCommandHandler());
            buildStage.EventBus.Subscribe(new SelectorCommandHandler());

            eventStage.EventBus = new EventBus();
            eventStage.EventBus.Subscribe(new EndTurnCommandHandler());
            
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