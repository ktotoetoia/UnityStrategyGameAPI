using System.Collections.Generic;

namespace TDS.SelectionSystem
{
    public interface ISelection
    {
        ISelectable First { get; }
        IEnumerable<ISelectable> Selected { get; }

        void Deselect();
    }
}