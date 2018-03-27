using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.GoombaSprites
{
    class WalkingGoombaSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;
        private const int millisecondsPerFrame = 300;

        private static Rectangle[] sourceFrames = {
            new Rectangle(0, 4, 16, 16),
            new Rectangle(30, 4, 16, 16)
        };

        public WalkingGoombaSprite(Texture2D spriteSheet)
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
