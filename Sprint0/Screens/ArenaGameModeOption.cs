using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Commands;
using SuperMarioBrothers.SpriteFonts;

namespace SuperMarioBrothers.Screens
{
    public class ArenaGameModeOption : IScreenOption
    {
        private SpriteFont font;
        private string text;
        private Vector2 location;

        public Vector2 Location
        {
            get
            {
                return location;
            }
        }

        public ArenaGameModeOption(string text, Vector2 location)
        {
            Initialize(text, location);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, text, location, Color.White);
            spriteBatch.End();
        }

        public void Select()
        {
            new StartArenaGameModeCommand().Execute();
        }

        private void Initialize(string text, Vector2 location)
        {
            font = SpriteFontFactory.Instance.GetOriginalHudFont();
            this.text = text;
            this.location = location;
        }
    }
}
