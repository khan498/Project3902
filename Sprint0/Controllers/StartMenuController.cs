using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SuperMarioBrothers.Commands;
using SuperMarioBrothers.Commands.MarioCommands;
using SuperMarioBrothers.Screens;
using System.Collections.Generic;

namespace SuperMarioBrothers.Controllers
{
    public class StartMenuController : IController
    {
        private IScreen startScreen;
        private Dictionary<Keys, ICommand> pressedKeyMap;
        KeyboardState currentKeyboardState;
        KeyboardState previousKeyboardState;

        public StartMenuController(IScreen startScreen)
        {
            Initialize(startScreen);
        }

        public void Update(GameTime gameTime)
        {
            currentKeyboardState = Keyboard.GetState();
            foreach (var mapValue in pressedKeyMap)
            {
                Keys key = mapValue.Key;
                if (currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key))
                {
                    pressedKeyMap[key].Execute();
                }
            }
            previousKeyboardState = currentKeyboardState;
        }

        private void Initialize(IScreen startScreen)
        {
            this.startScreen = startScreen;

            pressedKeyMap = new Dictionary<Keys, ICommand> {
                { Keys.Q, new QuitGameCommand()},
                { Keys.Enter, new StartScreenZCommand(startScreen.Cursor)},
                { Keys.Z, new StartScreenZCommand(startScreen.Cursor)},
                { Keys.Up, new MoveStartMenuCursorDownCommand(startScreen)},
                { Keys.Down, new MoveStartMenuCursorDownCommand(startScreen)}
            };
        }
    }
}
