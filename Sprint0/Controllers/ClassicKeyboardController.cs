using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioBrothers.Commands;
using SuperMarioBrothers.Commands.MarioCommands;
using SuperMarioBrothers.Entities.Mario;
using System.Collections.Generic;

namespace SuperMarioBrothers.Controllers
{
    class ClassicKeyboardController : IController
    {
        private Dictionary<Keys, ICommand> longPressKeyMap;
        private Dictionary<Keys, ICommand> singlePressKeyMap;
        private Dictionary<Keys, ICommand> pauseStateKeyMap;
        private Dictionary<Keys, ICommand> keysReleasedMap;

        private int timeSinceLastKeyPress = 0;
        private const int INPUT_DELAY = 10;
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        public ClassicKeyboardController(IPlayer player)
        {
            longPressKeyMap = new Dictionary<Keys, ICommand>
            {
                { Keys.Left, new LeftMarioCommand(player) },
                { Keys.A, new LeftMarioCommand(player) },
                { Keys.Right, new RightMarioCommand(player) },
                { Keys.D, new RightMarioCommand(player) },
                { Keys.Down, new DownMarioCommand(player) },
                { Keys.S, new DownMarioCommand(player) },
                { Keys.X, new RunMarioCommand(player) },
                { Keys.LeftShift, new RunMarioCommand(player) }
            };

            singlePressKeyMap = new Dictionary<Keys, ICommand>
            {
                { Keys.W, new UpMarioCommand(player) },
                { Keys.Up, new UpMarioCommand(player) },
                { Keys.Y, new SmallMarioCommand(player) },
                { Keys.U, new BigMarioCommand(player) },
                { Keys.I, new FireMarioCommand(player) },
                { Keys.O, new DeadMarioCommand(player) },
                { Keys.M, new MouseToggleCommand() },
                { Keys.X,  new LaunchFireBallCommand(player) },
                { Keys.LeftShift,  new LaunchFireBallCommand(player) },
                { Keys.R, new ResetCommand() }
            };

            pauseStateKeyMap = new Dictionary<Keys, ICommand>
            {
                { Keys.Escape, new PauseGameCommand() },
                { Keys.Q, new QuitGameCommand() },
            };

            keysReleasedMap = new Dictionary<Keys, ICommand>
            {
                { Keys.Down, new ReleaseDownKeyCommand() },
                { Keys.Right, new ReleaseRightKeyCommand() }
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
                ExecuteReleasedKeyCommands();
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

        private void ExecuteReleasedKeyCommands()
        {
            foreach (var mapValue in keysReleasedMap)
            {
                Keys key = mapValue.Key;
                if (currentKeyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key))
                {
                    keysReleasedMap[key].Execute();
                }
            }
        }
    }
}
