using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Sounds;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    public class LaunchFireBallCommand : ICommand
    {
        IPlayer player;

        public LaunchFireBallCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            if (player.IsMarioFire())
            {
                MarioGame.Instance.CurrentGameMode.CurrentLevel.ShootFireBall(player);
                SoundFactory.Instance.FireballSound();
            }
        }
    }
}