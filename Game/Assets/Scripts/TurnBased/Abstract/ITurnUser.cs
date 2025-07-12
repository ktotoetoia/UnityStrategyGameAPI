using System.Threading.Tasks;

namespace TDS.TurnSystem
{
    public interface ITurnUser
    {
        ValueTask ExecuteTurnAsync();
    }
}