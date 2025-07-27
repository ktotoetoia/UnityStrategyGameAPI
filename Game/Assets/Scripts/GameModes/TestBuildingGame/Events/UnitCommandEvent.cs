using TDS.Commands;

namespace BuildingsTestGame
{
    public class UnitCommandEvent : SingleValueEvent<CommandStatus>
    {
        public UnitCommandEvent(CommandStatus value) : base(value)
        {
            
        }
    }
}