using System.Collections.Generic;
using System.Linq;

namespace TDS.SelectionSystem
{
    public class Selection<T> : ISelection<T>
    {
        private List<T> _selected;

        public T First => _selected.FirstOrDefault();
        public IEnumerable<T> Selected => _selected;
     
        public Selection() : this(new List<T>())
        {
        }

        public Selection(T oneSelected) : this(new List<T> { oneSelected })
        {
        }

        public Selection(IEnumerable<T> selected) : this(selected.ToList())
        {
        }

        public Selection(List<T> selected)
        {
            _selected = new List<T>(selected);
        }
    }
}