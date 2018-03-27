using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioBrothers.Commands;
using SuperMarioBrothers.Commands.MarioCommands;
using SuperMarioBrothers.Entities.Mario;
using System.Collections.Generic;

namespace SuperMarioBrothers.Controllers
{
    class Player2KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> longPressKeyMap;
        private Dictionary<Keys, ICommand> singlePressKeyMap;

        private int timeSinceLastKeyPress = 0;
        private const int INPUT_DELAY = 10;
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        public Player2KeyboardController(IPlayer player)
        {
            longPressKeyMap = new Dictionary<Keys, ICommand>
            {     
                { Keys.RightShift, new RunMarioCommand(player)},
                { Keys.Left, new LeftMarioCommand(player) },
                { Keys.Right, new RightMarioCommand(player) },
                { Keys.Down, new DownMarioCommand(player) },
                { Keys.I, new FireMarioCommand(player) },
            };

            singlePressKeyMap = new Dictionary<Keys, ICommand>
            {
                { Keys.Up, new UpMarioCommand(player) },
                { Keys.RightShift,  new LaunchFireBallCommand(player) }
            };
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastKeyPress += gameTime.ElapsedGameTime.Milliseconds;
            currentKeyboardState = Keyboard.GetState();
            ExecuteLongPressControls();
            ExecuteSinglePressControls();
            previousKeyboardState = currentKeyboardState;
        }

        private void ExecuteLongPressControls()
        {
            if (timeSinceLastKeyPress > INPUT_DELAY)
            {
                timeSinceLastKeyPress -= INPUT_DELAY;
                Keys[] pressedKeys = currentKeyboardState.GetPressedKeys();
                foreach (Keys key in pressedKeys)
                {
                    if (longPressKeyMap.ContainsKey(key))
                        longPressKeyMap[key].Execute();
                }
            }
        }

        private void ExecuteSinglePressControls()
        {
            foreach (var mapValue in singlePressKeyMap)
            {
                Keys key = mapValue.Key;
                if (currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key))
                {
                    singlePressKeyMap[key].Execute();
                }
            }
        }
    }
}
