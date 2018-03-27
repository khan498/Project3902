using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.LuigiSprites.FireLuigi
{
    public class RightJumpingFireLuigiSprite : ISprite
    {
        private const int millisecondsPerFrame = 0;

        private static Rectangle[] sourceFrames = {
            new Rectangle(362, 122, 16, 32)
        };

        private SpriteDrawer spriteDrawer;

        public RightJumpingFireLuigiSprite(Texture2D spriteSheet)
        {
            spriteDrawer = new SpriteDrawer(spriteSheet, sourceFrames, millisecondsPerFrame);
        }

        public void Update(GameTime gameTime)
        {
            // not animated
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {

            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }
    }
}

