namespace SuperMarioBrothers.Commands
{
    public class ReleaseDownKeyCommand : ICommand
    {
        public void Execute()
        {
            MarioGame.Instance.DownIsBeingPressed = false;
        }
    }
}
