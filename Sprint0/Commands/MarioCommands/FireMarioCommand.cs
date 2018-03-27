using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Sounds;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    public class FireMarioCommand : ICommand
    {
        IPlayer player;

        public FireMarioCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.BeFire();
        }
    }
}
