using SuperMarioBrothers.GameModes;

namespace SuperMarioBrothers.Commands
{
    public class StartClassicGameCommand : ICommand
    {
        public void Execute()
        {
            MarioGame.Instance.IsShowingStartScreen = false;
            MarioGame.Instance.CurrentGameMode = new ClassicGameMode(MarioGame.Instance);
        }
    }
}
