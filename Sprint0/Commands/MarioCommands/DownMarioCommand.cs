using SuperMarioBrothers.Entities.Mario;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    public class DownMarioCommand : ICommand
    {
        IPlayer player;

        public DownMarioCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.DownMovement();
            MarioGame.Instance.DownIsBeingPressed = true;
        }
    }
}
