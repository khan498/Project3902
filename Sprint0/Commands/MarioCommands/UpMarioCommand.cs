using SuperMarioBrothers.Entities.Mario;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    public class UpMarioCommand : ICommand
    {
        IPlayer player;

        public UpMarioCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.UpMovement();
        }
    }
}
