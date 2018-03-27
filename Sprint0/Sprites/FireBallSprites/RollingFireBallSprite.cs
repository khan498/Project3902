using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.FireBallSprites
{
    class RollingFireBallSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;
        private const int millisecondsPerFrame = 100;

        private static Rectangle[] sourceFrames = {
            new Rectangle(313, 945, 8, 8),
            new Rectangle(324, 945, 8, 8),
            new Rectangle(336, 945, 8, 8),
            new Rectangle(348, 945, 8, 8)
        };

        public RollingFireBallSprite(Texture2D spriteSheet)
        {
            spriteDrawer = new SpriteDrawer(spriteSheet, sourceFrames, millisecondsPerFrame);
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
