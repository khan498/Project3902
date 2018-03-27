using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.ItemSprites
{
    class CoinSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;
        private const int millisecondsPerFrame = 100;

        private static Rectangle[] sourceFrames = {
            new Rectangle(128, 95, 8, 14),
            new Rectangle(158, 95, 8, 14),
            new Rectangle(188, 95, 8, 14),
            new Rectangle(218, 95, 8, 14)
        };
        
        public CoinSprite(Texture2D spriteSheet)
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