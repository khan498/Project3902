using SuperMarioBrothers.Entities.Mario;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    public class SmallMarioCommand : ICommand
    {
        IPlayer player;

        public SmallMarioCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.BeSmall();
        }
    }
}
