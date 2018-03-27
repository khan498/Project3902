using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.KoopaSprites
{
    class RightWalkingGreenKoopaSprite : ISprite
    {
        private const int millisecondsPerFrame = 300;

        private static Rectangle[] sourceFrames = {
            new Rectangle(210, 0, 16, 24),
            new Rectangle(240, 0, 16, 24)
        };

        private SpriteDrawer spriteDrawer;

        public RightWalkingGreenKoopaSprite(Texture2D spriteSheet)
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
