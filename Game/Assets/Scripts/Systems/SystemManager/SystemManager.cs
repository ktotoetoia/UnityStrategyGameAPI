using System;
using System.Collections.Generic;
using System.Linq;
using TDS.Factions;
using TDS.Worlds;

namespace TDS.Systems
{
    public class SystemManager : ISystemManager
    {
        private readonly List<ISystem>  _systems;
        
        public ICollection<ISystem> Systems => _systems;

        public SystemManager()
        {
            _systems = new List<ISystem>();
        }
        
        public void InjectAll(IEnumerable<ISystemUser> users)
        {
            foreach (ISystemUser user in users)
            {
                IEnumerable<Type> requiredSystems = user.GetRequiredSystems();
                List<ISystem> toInject = new List<ISystem>();

                foreach (Type type in requiredSystems)
                {
                    if (!typeof(ISystem).IsAssignableFrom(type))
                    {
                        throw new Exception($"Type {type.Name} does not implement ISystemReadonly");
                    }

                    ISystem resolved = Systems.FirstOrDefault(s => type.IsAssignableFrom(s.GetType()));

                    if (resolved == null)
                    {
                        throw new Exception($"System of type {type.Name} was not found.");
                    }

                    toInject.Add(resolved);
                }

                user.Inject(toInject);
            }
        }
    }
}