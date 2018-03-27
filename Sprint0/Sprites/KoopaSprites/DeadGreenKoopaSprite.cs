using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.KoopaSprites
{
    class DeadGreenKoopaSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;
        private const int millisecondsPerFrame = 0;

        private static Rectangle[] sourceFrames = {
            new Rectangle(360, 5, 16, 14)
        };

        public DeadGreenKoopaSprite(Texture2D spriteSheet)
        {
            spriteDrawer = new SpriteDrawer(spriteSheet, sourceFrames, millisecondsPerFrame);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {
            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }

        public void Update(GameTime gameTime)
        {
            //not Animated
        }
    }
}