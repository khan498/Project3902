using SuperMarioBrothers.Entities.Mario;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    public class LeftMarioCommand : ICommand
    {
        IPlayer player;

        public LeftMarioCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.LeftMovement();
            player.RunActivated = false;
        }
    }
}
