using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioBrothers.Commands;
using SuperMarioBrothers.Commands.MarioCommands;
using SuperMarioBrothers.Entities.Mario;
using System.Collections.Generic;

namespace SuperMarioBrothers.Controllers
{
    class Player1KeyboardController : IController
    {
        private Dictionary<Keys, ICommand> longPressKeyMap;
        private Dictionary<Keys, ICommand> singlePressKeyMap;
        private Dictionary<Keys, ICommand> pauseStateKeyMap;

        private int timeSinceLastKeyPress = 0;
        private const int INPUT_DELAY = 10;
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        public Player1KeyboardController(IPlayer player)
        {
            longPressKeyMap = new Dictionary<Keys, ICommand>
            {
                { Keys.A, new LeftMarioCommand(player) },
                { Keys.D, new RightMarioCommand(player) },
                { Keys.S, new DownMarioCommand(player) },
                { Keys.LeftShift, new RunMarioCommand(player)},
                { Keys.I, new FireMarioCommand(player) },
            };

            singlePressKeyMap = new Dictionary<Keys, ICommand>
            {
                { Keys.W, new UpMarioCommand(player) },
                { Keys.M, new MouseToggleCommand() },
                { Keys.LeftShift,  new LaunchFireBallCommand(player) },
                { Keys.R, new ResetCommand() }
            };

            pauseStateKeyMap = new Dictionary<Keys, ICommand>
            {
                { Keys.Escape, new PauseGameCommand() },
                { Keys.Q, new QuitGameCommand() },
            };
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastKeyPress += gameTime.ElapsedGameTime.Milliseconds;
            currentKeyboardState = Keyboard.GetState();
            ExecutePauseControls();
            if (!MarioGame.Instance.CurrentGameMode.IsPaused)
            {
                ExecuteLongPressControls();
                ExecuteSinglePressControls();
            }
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

        private void ExecutePauseControls()
        {
            foreach (var mapValue in pauseStateKeyMap)
            {
                Keys key = mapValue.Key;
                if (currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key))
                {
                    pauseStateKeyMap[key].Execute();
                }
            }
        }
    }
}
