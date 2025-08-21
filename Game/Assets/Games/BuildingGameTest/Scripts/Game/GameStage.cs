using System.Collections.Generic;
using System.Linq;
using TDS.TurnSystem;

namespace BuildingsTestGame
{
    public class GameStage : TurnUser, IGameStage
    {
        public ICollection<IGameService> Services { get; }

        public GameStage() : this(new List<IGameService>())
        {
            
        }
        
        public GameStage(ICollection<IGameService> services)
        {
            Services = services;
        }
        
        public T GetService<T>() where T : IGameService
        {
            return Services.OfType<T>().FirstOrDefault();
        }
    }
}