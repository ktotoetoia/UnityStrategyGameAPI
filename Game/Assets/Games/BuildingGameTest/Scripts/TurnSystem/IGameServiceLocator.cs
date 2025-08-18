using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BuildingsTestGame
{
    public interface IGameServiceLocator
    {
        public T GetService<T>() where T : IGameService;
    }
}