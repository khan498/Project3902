namespace SuperMarioBrothers.Commands.MarioCommands
{

    public class QuitGameCommand : ICommand
    {
        public QuitGameCommand()
        {
        }

        public void Execute()
        {
            MarioGame.Instance.Exit();
        }
    }
}
