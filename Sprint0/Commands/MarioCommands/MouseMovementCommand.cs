using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    public class MouseMovementCommand : ICommand
    {
        private MouseState state;

        public MouseMovementCommand(MouseState state)
        {
            this.state = state;
        }

        public void Execute()
        {
            Rectangle marioRectangle = MarioGame.Instance.CurrentGameMode.Players[0].DestinationRectangle;

            MarioGame.Instance.CurrentGameMode.Players[0].DestinationRectangle = new Rectangle(state.X, state.Y, marioRectangle.Width, marioRectangle.Height);
        }
    }
    

}
