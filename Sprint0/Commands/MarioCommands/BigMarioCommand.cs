using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Sounds;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    public class BigMarioCommand : ICommand
    {
        IPlayer player;

        public BigMarioCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.BeBig();
            SoundFactory.Instance.PowerUpSound();
        }
    }
}
