using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.MarioSprites.SmallMario
{
    public class DeadMarioSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;
        private const int millisecondsPerFrame = 0;

        private static Rectangle[] sourceFrames = {
            new Rectangle(0, 16, 15, 14)
        };

        public DeadMarioSprite(Texture2D texture)
        {
            spriteDrawer = new SpriteDrawer(texture, sourceFrames, millisecondsPerFrame);
        }

        public void Update(GameTime gameTime)
        {
            // Does not animate
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {

            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }
    }
}
 

