namespace SuperMarioBrothers.Commands.MarioCommands
{

    public class ResetCommand : ICommand
    {
        public ResetCommand()
        {
        }

        public void Execute()
        {
            MarioGame.Instance.HardResetGame();
        }
    }
}
