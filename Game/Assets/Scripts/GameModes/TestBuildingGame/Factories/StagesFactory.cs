using TDS;
using TDS.Commands;

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
            
            GameStage assignStage = new GameStage(new TurnCommandSequencer(assignSeq));
            GameStage buildStage = new GameStage(new TurnCommandSequencer(buildSeq));
            GameStage eventStage = new GameStage(new TurnCommandSequencer(eventSeq));

            return (assignStage,buildStage,eventStage);
        }
    }
}