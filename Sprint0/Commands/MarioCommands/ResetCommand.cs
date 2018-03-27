using SuperMarioBrothers.Interfaces;
//Ziheng Wei
namespace SuperMarioBrothers.MarioCommands
{

    public class ResetCommand : ICommand
    {
        private MarioGame myGame;

        public ResetCommand(MarioGame game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame = new MarioGame();
        }
    }
}
