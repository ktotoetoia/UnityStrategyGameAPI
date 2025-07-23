using TDS.Commands;

namespace BuildingsTestGame
{
    public class SelectorCommandHandler : IEventHandler<SelectAtPositionCommand>
    {
        public void Handle(SelectAtPositionCommand evt)
        {
            evt.Selector.UpdateSelection(evt.Position);
        }
    }
}