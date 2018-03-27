using SuperMarioBrothers.Entities.Mario;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    public class DeadMarioCommand : ICommand
    {
        IPlayer player;

        public DeadMarioCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.BeDead();
        }
    }
}
