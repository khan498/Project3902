using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.BlockSprites
{
    class SolidBlock1Sprite : ISprite
    {
        private SpriteDrawer spriteDrawer;
        private const int millisecondsPerFrame = 0;

        private static Rectangle[] sourceFrames = {
            new Rectangle(373, 124, 16, 16)
        };

        public SolidBlock1Sprite(Texture2D spriteSheet)
        {
            spriteDrawer = new SpriteDrawer(spriteSheet, sourceFrames, millisecondsPerFrame);
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {
            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }
    }
}
