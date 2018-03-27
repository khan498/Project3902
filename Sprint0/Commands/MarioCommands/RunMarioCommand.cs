using SuperMarioBrothers.Entities.Mario;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    public class RunMarioCommand : ICommand
    {
        IPlayer player;

        public RunMarioCommand(IPlayer player)
        {
            this.player = player;
        }

        public void Execute()
        {
            player.RunActivated = true;
        }
    }
}
