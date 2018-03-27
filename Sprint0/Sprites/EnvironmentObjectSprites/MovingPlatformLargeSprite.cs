using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.EnvironmentObjectSprites
{
    public class MovingPlatformLargeSprite : ISprite
    {
        private const int millisecondsPerFrame = 0;
        private static Rectangle[] sourceFrames = {
            new Rectangle(143, 43, 48, 8)
        };
        private SpriteDrawer spriteDrawer;

        public MovingPlatformLargeSprite(Texture2D spriteSheet)
        {
            Initialize(spriteSheet);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {
            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }

        public void Update(GameTime gameTime)
        {
            spriteDrawer.Update(gameTime);
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
