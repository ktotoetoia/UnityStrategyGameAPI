using System;
using System.Collections.Generic;
using System.Linq;
using TDS.Factions;

namespace TDS.Systems
{
    public interface ISystemManager
    {
        public ICollection<ISystem> Systems { get; }
        public void InjectAll(IEnumerable<ISystemUser> users);
    }

    public interface ISystemUser
    {
        IEnumerable<Type> GetRequiredSystems();
        void Inject(IEnumerable<ISystem> systems);
    }
}