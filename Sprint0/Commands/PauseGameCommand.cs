using SuperMarioBrothers.Sounds;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    class PauseGameCommand : ICommand
    {
        public PauseGameCommand()
        {

        }
        public void Execute()
        {
            if (!MarioGame.Instance.CurrentGameMode.IsPaused)
            {
                SoundFactory.Instance.PauseSound();
                MarioGame.Instance.PauseGame();
            }
            else
            {
                MarioGame.Instance.UnpauseGame();
            }
        }
    }
}
