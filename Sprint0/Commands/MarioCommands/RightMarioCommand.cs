using SuperMarioBrothers.Entities.Mario;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    public class RightMarioCommand : ICommand
    {
        IPlayer player;

        public RightMarioCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.RightMovement();
            player.RunActivated = false;
            MarioGame.Instance.RightIsBeingPressed = true;
        }
    }
}
