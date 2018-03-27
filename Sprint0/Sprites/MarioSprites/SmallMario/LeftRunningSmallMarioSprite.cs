using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.MarioSprites.SmallMario
{
    class LeftRunningSmallMarioSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;
        private const int millisecondsPerFrame = 100;

        private static Rectangle[] sourceFrames = {
            new Rectangle(150, 0, 14, 16),
            new Rectangle(120, 0, 14, 16),
            new Rectangle(89, 0, 16, 16),
        };

        public LeftRunningSmallMarioSprite(Texture2D texture)
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
