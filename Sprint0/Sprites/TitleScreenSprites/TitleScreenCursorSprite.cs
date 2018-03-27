using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.TitleScreenSprites
{
    public class TitleScreenCursorSprite : ISprite
    {
        private const int millisecondsPerFrame = 0;
        private static Rectangle[] sourceFrames = {
            new Rectangle(3, 155, 8, 8)
        };
        private SpriteDrawer spriteDrawer;

        public TitleScreenCursorSprite(Texture2D spriteSheet)
        {
            Initialize(spriteSheet);
        }

        public void Update(GameTime gameTime)
        {
            // Does not animate
        }

        public void Draw(
            SpriteBatch spriteBatch, 
            Rectangle destinationRectangle, 
            Color color
        )
        {
            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }

        private void Initialize(Texture2D spriteSheet)
        {
            spriteDrawer = new SpriteDrawer(
                spriteSheet, 
                sourceFrames, 
                millisecondsPerFrame
            );
        }
    }
}
