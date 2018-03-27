using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.KoopaSprites
{
    class FlippedLeftGreenKoopaSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;
        private const int millisecondsPerFrame = 0;

        private static Rectangle[] sourceFrames = {
            new Rectangle(377, 226, 16, 23)
        };

        public FlippedLeftGreenKoopaSprite(Texture2D spriteSheet)
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
