using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.KoopaSprites
{
    class LeftWalkingGreenKoopaSprite : ISprite
    {
        private const int millisecondsPerFrame = 200;

        private static Rectangle[] sourceFrames = {
            new Rectangle(180, 0, 16, 24),
            new Rectangle(150, 0, 16, 24)
        };

        private SpriteDrawer spriteDrawer;

        public LeftWalkingGreenKoopaSprite(Texture2D spriteSheet)
        {
            spriteDrawer = new SpriteDrawer(spriteSheet, sourceFrames, millisecondsPerFrame);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {
            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }

        public void Update(GameTime gameTime)
        {
            spriteDrawer.Update(gameTime);
        }
    }
}
