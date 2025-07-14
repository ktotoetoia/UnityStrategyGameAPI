using System.Collections.Generic;
using System.Linq;

namespace TDS.SelectionSystem
{
    public class Selection : ISelection
    {
        public ISelectable First { get; private set; }
        public IEnumerable<ISelectable> Selected { get; private set; }
     
        public Selection() : this(null, new List<ISelectable>())
        {
        }

        public Selection(ISelectable oneSelected) : this(oneSelected, new List<ISelectable> { oneSelected })
        {
        }

        public Selection(IEnumerable<ISelectable> selected) : this(selected.FirstOrDefault(), selected)
        {
        }

        public Selection(ISelectable first, IEnumerable<ISelectable> selected)
        {
            First = first;
            Selected = selected;

            foreach (ISelectable sel in selected)
            {
                sel.OnSelected();
            }
        }

        public void Deselect()
        {
            foreach (ISelectable selected in Selected)
            {
                selected.OnDeselected();
            }

            First = null;
            Selected = new List<ISelectable>();
        }
    }
}