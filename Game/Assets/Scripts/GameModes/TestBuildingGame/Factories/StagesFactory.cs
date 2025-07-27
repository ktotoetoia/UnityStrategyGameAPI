using System.Collections.Generic;
using TDS;
using TDS.Commands;
using TDS.Events;
using TDS.SelectionSystem;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class StagesFactory : IFactory<(GameStage,GameStage,GameStage)>
    {
        public (GameStage,GameStage,GameStage) Create()
        {
            CommandSequencer assignSeq = new CommandSequencer();
            assignSeq.HandlersList.Add(new EndTurnCommandHandler());
            assignSeq.HandlersList.Add(new CreateUnitCommandHandler());
            assignSeq.HandlersList.Add(new MoveUnitCommandHandler());
            
            CommandSequencer buildSeq = new CommandSequencer();
            buildSeq.HandlersList.Add(new EndTurnCommandHandler());

            CommandSequencer eventSeq = new CommandSequencer();
            eventSeq.HandlersList.Add(new EndTurnCommandHandler());
            
            GameStage assignStage = new GameStage(assignSeq);
            GameStage buildStage = new GameStage(buildSeq);
            GameStage eventStage = new GameStage(eventSeq);

            return (assignStage,buildStage,eventStage);
        }
    }
}