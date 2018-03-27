namespace SuperMarioBrothers.Commands
{
    public class ReleaseRightKeyCommand : ICommand
    {
        public void Execute()
        {
            MarioGame.Instance.RightIsBeingPressed = false;
        }
    }
}
