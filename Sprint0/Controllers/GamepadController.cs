using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using SuperMarioBrothers.Commands;
using SuperMarioBrothers.Commands.MarioCommands;
using SuperMarioBrothers.Entities.Mario;

namespace SuperMarioBrothers.Controllers
{
    class GamepadController : IController
    {
        private ICommand quitGameCommand;
        private ICommand upMarioCommand;
        private ICommand downMarioCommand;
        private ICommand leftMarioCommand;
        private ICommand rightMarioCommand;
        private ICommand fireBallCommand;
        private ICommand sprintCommand;

        public GamepadController(IPlayer player)
        {
            quitGameCommand = new QuitGameCommand();
            upMarioCommand = new UpMarioCommand(player);
            downMarioCommand = new DownMarioCommand(player);
            leftMarioCommand = new LeftMarioCommand(player);
            rightMarioCommand = new RightMarioCommand(player);
            fireBallCommand = new LaunchFireBallCommand(player);
            sprintCommand = new RunMarioCommand(player);
        }

        public void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Start == ButtonState.Pressed)
            {
                quitGameCommand.Execute();
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.A == ButtonState.Pressed)
            {
                fireBallCommand.Execute();
                sprintCommand.Execute();
            }
            Vector2 vector = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left;
            if (vector.X > 0)
            {
                rightMarioCommand.Execute();
            }
            if (vector.X < 0)
            {
                leftMarioCommand.Execute();
            }
            if (vector.Y > 0)
            {
                upMarioCommand.Execute();
            }
            if (vector.Y < 0)
            {
                downMarioCommand.Execute();
            }

        }
    }
}
