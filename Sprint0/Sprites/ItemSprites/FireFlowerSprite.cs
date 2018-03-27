using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.ItemSprites
{
    class FireFlowerSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;
        private const int millisecondsPerFrame = 100;

        private static Rectangle[] sourceFrames = {
            new Rectangle(94, 64, 16, 16),
            new Rectangle(64, 64, 16, 16),
            new Rectangle(34, 64, 16, 16),
            new Rectangle(4, 64, 16, 16)
        };
        
        public FireFlowerSprite(Texture2D spriteSheet)
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