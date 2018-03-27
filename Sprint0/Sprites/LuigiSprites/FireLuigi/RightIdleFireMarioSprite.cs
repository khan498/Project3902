using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.LuigiSprites.FireLuigi
{
    class RightIdleFireLuigiSprite : ISprite
    {
        private const int millisecondsPerFrame = 0;

        private static Rectangle[] sourceFrames = {
            new Rectangle(209, 122, 16, 32)
        };

        private SpriteDrawer spriteDrawer;

        public RightIdleFireLuigiSprite(Texture2D spriteSheet)
        {
            spriteDrawer = new SpriteDrawer(spriteSheet, sourceFrames, millisecondsPerFrame);
        }

        public void Update(GameTime gameTime)
        {
            // Not animated
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {


            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }
    }
}
