namespace TDS.SelectionSystem
{
    public interface ISelectable
    {
        object Object { get; }

        void OnSelected();
        void OnDeselected();
    }
}