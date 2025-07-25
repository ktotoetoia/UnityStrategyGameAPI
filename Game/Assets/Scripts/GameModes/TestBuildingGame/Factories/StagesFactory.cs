using System.Collections.Generic;
using TDS;
using TDS.Commands;
using TDS.Events;
using TDS.SelectionSystem;
using TDS.Worlds;

namespace BuildingsTestGame
{
    public class StagesFactory : IFactory<(GameStage,GameStage,GameStage),IWorld>
    {
        public (GameStage,GameStage,GameStage) Create(IWorld world)
        {
            CommandSequencer assignSeq = new CommandSequencer();
            assignSeq.HandlersList.Add(new EndTurnCommandHandler());
            assignSeq.HandlersList.Add(new CreateUnitCommandHandler());
            assignSeq.HandlersList.Add(new MoveUnitCommandHandler());
            assignSeq.HandlersList.Add(new SelectorCommandHandler());
            
            CommandSequencer buildSeq = new CommandSequencer();
            buildSeq.HandlersList.Add(new EndTurnCommandHandler());
            buildSeq.HandlersList.Add(new SelectorCommandHandler());

            CommandSequencer eventSeq = new CommandSequencer();
            eventSeq.HandlersList.Add(new EndTurnCommandHandler());
            
            GameStage assignStage = new GameStage(assignSeq);
            GameStage buildStage = new GameStage(buildSeq);
            GameStage eventStage = new GameStage(eventSeq);

            return (assignStage,buildStage,eventStage);
        }
    }
}