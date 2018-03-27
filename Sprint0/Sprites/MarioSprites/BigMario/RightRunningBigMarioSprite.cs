using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioBrothers.Sprites.MarioSprites.BigMario
{
    class RightRunningBigMarioSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;

        private static Rectangle[] sourceFrames = {
            new Rectangle(299, 52, 16, 32),
            new Rectangle(269, 52, 16, 32),
            new Rectangle(239, 52, 16, 32)
        };
        
        private const int millisecondsPerFrame = 100;

        public RightRunningBigMarioSprite(Texture2D texture)
        {
            spriteDrawer = new SpriteDrawer(texture, sourceFrames, millisecondsPerFrame);
        }
        public void Update(GameTime gameTime)
        {
             spriteDrawer.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {

            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }
    }
}
