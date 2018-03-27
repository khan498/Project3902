using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioBrothers.Commands.MarioCommands;

namespace SuperMarioBrothers.Controllers
{
    class MouseController : IController
    {
        private MouseState state;
        private bool mouseControl = false;
        MouseMovementCommand mouseMovement;

        private static MouseController instance = new MouseController();
        
        private MouseController()
        {
            state = new MouseState();
        }

        public static MouseController Instance
        {
            get
            {
                return instance;
            }
        }

        public bool IsMouseToggled
        {
            get { return mouseControl; }
        }

        public void Update(GameTime gameTime)
        {
            if (mouseControl)
            {
                state = Mouse.GetState();
                mouseMovement = new MouseMovementCommand(state);
                mouseMovement.Execute();
            }
        }

        public void MouseToggle()
        {
            mouseControl = !mouseControl;
        }
    }
}
