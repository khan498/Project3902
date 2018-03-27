using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites
{
    public class CoinCounterSprite : ISprite
    {
        private static Rectangle[] sourceFrames = {
            new Rectangle(463, 164, 5, 8),
            new Rectangle(470, 164, 5, 8),
            new Rectangle(477, 164, 5, 8)
        };
        private const int MS_PER_FRAME = 200;

        private SpriteDrawer spriteDrawer;

        public CoinCounterSprite(Texture2D spriteSheet)
        {
            Initialize(spriteSheet);
        }

        public void Update(GameTime gameTime)
        {
            spriteDrawer.Update(gameTime);
        }

        public void Draw(
            SpriteBatch spriteBatch, 
            Rectangle destinationRectangle, 
            Color color
        )
        {
            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }

        private void Initialize(Texture2D spriteSheet)
        {
            spriteDrawer = new SpriteDrawer(
                spriteSheet, 
                sourceFrames, 
                MS_PER_FRAME
            );
        }
    }
}
