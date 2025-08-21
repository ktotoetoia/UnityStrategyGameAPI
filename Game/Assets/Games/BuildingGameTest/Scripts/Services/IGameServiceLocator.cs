using UnityEngine;

namespace BuildingsTestGame
{
    public interface IGameServiceLocator
    {
        public T GetService<T>() where T : IGameService;
    }
}