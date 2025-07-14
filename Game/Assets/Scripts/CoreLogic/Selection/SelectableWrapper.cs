namespace TDS.SelectionSystem
{
    public class SelectableWrapper : ISelectable
    {
        public object Object { get; set; }
        
        public SelectableWrapper(object obj)
        {
            Object = obj;
        }

        public void OnDeselected()
        {
        }

        public void OnSelected()
        {
        }
    }
}