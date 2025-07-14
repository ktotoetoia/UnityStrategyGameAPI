using TDS.Commands;

namespace BuildingsTestGame
{
    public class LegacyInputStageFactory : IStageFactory
    {
        public IGameStage CreateAssignStage()
        {
            GameStage stage = new GameStage();

            stage.CommandListener = new AssignStageCommandListener(stage);
            stage.InputHandler = new AssignStageLegacyInput();

            return stage;
        }

        public IGameStage CreateBuildStage()
        {            
            GameStage stage = new GameStage();

            stage.CommandListener = new BuildStageCommandListener(stage);
            stage.InputHandler = new BuildStageLegacyInput();

            return stage;
        }

        public IGameStage CreateEventStage()
        {
            GameStage stage = new GameStage();

            stage.CommandListener = new EventStageCommandListener(stage);
            stage.InputHandler = new BuildStageLegacyInput();
            
            return stage;
        }
    }
}