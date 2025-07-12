namespace TDS.TurnSystem
{
    public interface ITurnObject
    {
        void OnTurnStart();
        void OnTurnEnd();
    }
}