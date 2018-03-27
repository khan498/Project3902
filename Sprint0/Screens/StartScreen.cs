using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Controllers;
using SuperMarioBrothers.SpriteFonts;
using SuperMarioBrothers.Sprites;
using System.Collections.Generic;

namespace SuperMarioBrothers.Screens
{
    public class StartScreen : IScreen
    {
        private ISprite titleSprite;
        private IScreenCursor cursor;
        private List<IScreenOption> options;
        private IController controller;

        public IScreenCursor Cursor
        {
            get
            {
                return cursor;
            }
        }

        public StartScreen()
        {
            Initialize();
        }

        public void Update(GameTime gameTime)
        {
            controller.Update(gameTime);
            titleSprite.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawOptions(spriteBatch);
            cursor.Draw(spriteBatch);
            titleSprite.Draw(
                spriteBatch,
                new Rectangle(100, 50, 600, 200),
                Color.White
            );
        }

        public void SelectNextOption()
        {
            int i = options.IndexOf(cursor.CurrentOption);

            if ( i >= options.Count - 1)
            {
                i = 0;
            }
            else
            {
                i++;
            }

            cursor.MoveTo(options[i]);
        }

        private void Initialize()
        {
            InitializeOptions();
            cursor = new StartScreenCursor(options[0]);
            controller = new StartMenuController(this);
            titleSprite = SpriteFactory.Instance.GetTitleScreenTitleSprite();
        }

        private void InitializeOptions()
        {
            options = new List<IScreenOption>()
            {
                new ClassicGameModeOption("Classic", new Vector2(300, 300)),
                new ArenaGameModeOption("Arena", new Vector2(300, 400))
            };
        }

        private void DrawOptions(SpriteBatch spriteBatch)
        {
            foreach (IScreenOption option in options)
            {
                option.Draw(spriteBatch);
            }
        }
    }
}
