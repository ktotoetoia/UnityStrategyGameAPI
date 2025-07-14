using System.Collections.Generic;

namespace TDS.Graphs
{
    public interface INode : INodeReadOnly, ICollection<IEdge>
    {
    }
}