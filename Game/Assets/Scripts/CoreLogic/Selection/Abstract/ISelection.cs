using System.Collections.Generic;

namespace TDS.SelectionSystem
{
    public interface ISelection<out T>
    {
        T First { get; }
        IEnumerable<T> Selected { get; }

        void Deselect();
    }
}