using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioBrothers.Sprites.MarioSprites.BigMario
{
    class LeftIdleBigMarioSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;
        private const int millisecondsPerFrame = 0;

        private static Rectangle[] sourceFrames = {
            new Rectangle(180, 52, 16, 32)
        };
        
        public LeftIdleBigMarioSprite(Texture2D texture)
        {
            spriteDrawer = new SpriteDrawer(texture, sourceFrames, millisecondsPerFrame);
        }

        public void Update(GameTime gameTime)
        {
            //not animated
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {
            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }
    }
}
