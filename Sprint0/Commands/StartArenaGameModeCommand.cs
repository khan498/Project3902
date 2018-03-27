using SuperMarioBrothers.GameModes;

namespace SuperMarioBrothers.Commands
{
    public class StartArenaGameModeCommand : ICommand
    {
        public void Execute()
        {
            MarioGame.Instance.IsShowingStartScreen = false;
            MarioGame.Instance.CurrentGameMode = new ArenaGameMode(MarioGame.Instance);
        }
    }
}
