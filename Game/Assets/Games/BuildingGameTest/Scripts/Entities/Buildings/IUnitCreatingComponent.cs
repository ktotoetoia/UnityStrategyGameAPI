using System.Collections;
using System.Collections.Generic;
using TDS.Components;

namespace BuildingsTestGame
{
    public interface IUnitCreatingComponent : IComponent
    {
        IReadOnlyList<IUnitInfo> UnitInfos { get; }
        
        void AddToQueue(IUnitInfo unitInfo);

        IList GetItemSource();
    }
}