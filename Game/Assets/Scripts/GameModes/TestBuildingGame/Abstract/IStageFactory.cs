namespace BuildingsTestGame
{
    public interface IStageFactory
    {
        IGameStage CreateAssignStage();
        IGameStage CreateEventStage();
        IGameStage CreateBuildStage();
    }
}