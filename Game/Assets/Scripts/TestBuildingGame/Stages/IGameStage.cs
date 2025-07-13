using TDS.Commands;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public interface IGameStage : ICommandListener, ITurnUser
    {
        
    }
}