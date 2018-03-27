using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Commands;
using SuperMarioBrothers.SpriteFonts;

namespace SuperMarioBrothers.Screens
{
    public class ClassicGameModeOption : IScreenOption
    {
        private string text;
        private SpriteFont font;
        private Vector2 location;

        public Vector2 Location
        {
            get
            {
                return location;
            }
        }

        public ClassicGameModeOption(string text, Vector2 location)
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
            new StartClassicGameCommand().Execute();
        }

        private void Initialize(string text, Vector2 location)
        {
            this.text = text;
            font = SpriteFontFactory.Instance.GetOriginalHudFont();
            this.location = location;
        }
    }
}
