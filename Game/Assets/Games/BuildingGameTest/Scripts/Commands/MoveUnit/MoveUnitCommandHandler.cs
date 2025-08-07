using System.Linq;
using TDS.Commands;
using TDS.Entities;
using TDS.Graphs;
using TDS.Handlers;
using TDS.Maps;

namespace BuildingsTestGame
{
    public class MoveUnitCommandHandler : IHandler<ICommand>
    {
        public bool CanHandle(ICommand command)
        {
            return command is MoveUnitCommand moveUnitCommand &&
                   moveUnitCommand.Path.Start.Value is GameTerrain &&
                   moveUnitCommand.Path.End.Value is GameTerrain;
        }

        public void Handle(ICommand command)
        {
            if (command is MoveUnitCommand moveUnitCommand && moveUnitCommand.Unit.TryGetComponent(out IMapMovementComponent component))
            {
                float pointsLeft = component.MovementPoints;

                foreach (INode<ITerrain> node in moveUnitCommand.Path.Nodes)
                {
                    if (node == moveUnitCommand.Path.Start)
                    {
                        continue;
                    }

                    if (pointsLeft <= 0)
                    {
                        break;
                    }

                    (node.Value as IGameTerrain).Unit = moveUnitCommand.Unit;
                    pointsLeft -= 1;
                }
            }
        }
    }
}