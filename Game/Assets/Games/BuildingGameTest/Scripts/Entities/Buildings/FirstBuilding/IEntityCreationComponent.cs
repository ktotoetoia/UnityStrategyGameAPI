using System.Collections;
using System.Collections.Generic;
using TDS.Components;

namespace BuildingsTestGame
{
    public interface IEntityCreationComponent : IComponent
    {
        IReadOnlyList<IEntityInfo> EntityInfos { get; }
        
        void AddToQueue(IEntityInfo entityInfo);

        IList GetItemSource();
    }
}