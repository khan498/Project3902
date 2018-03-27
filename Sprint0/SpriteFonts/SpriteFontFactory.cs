using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.SpriteFonts
{
    public class SpriteFontFactory
    {
        private static SpriteFontFactory instance = new SpriteFontFactory();

        SpriteFont originalHudFont;

        public static SpriteFontFactory Instance
        {
            get
            {
                return instance;
            }
        }

        private SpriteFontFactory()
        {
        }

        public void LoadAllFonts(ContentManager manager)
        {
            originalHudFont = manager.Load<SpriteFont>("SpriteFonts/Arial");
        }

        public SpriteFont GetOriginalHudFont()
        {
            return originalHudFont;
        }
    }
}
