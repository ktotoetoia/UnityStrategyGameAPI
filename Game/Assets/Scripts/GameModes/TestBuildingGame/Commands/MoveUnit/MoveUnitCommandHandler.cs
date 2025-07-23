using TDS.Commands;

namespace BuildingsTestGame
{
    public class MoveUnitCommandHandler : IEventHandler<MoveUnitCommand>
    {
        public void Handle(MoveUnitCommand evt)
        {            
            if (evt.Path.Start.Value is BuildingTerrain t1 && evt.Path.End.Value is BuildingTerrain t2)
            {
                t1.Unit = null;
                t2.Unit = evt.Unit;
            }
        }
    }
}