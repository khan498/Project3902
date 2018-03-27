using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioBrothers.Sprites.LuigiSprites.BigLuigi
{
    class LeftRunningBigLuigiSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;

        private static Rectangle[] sourceFrames = {
            new Rectangle(90, 52, 16, 32),
            new Rectangle(120, 52, 16, 32),
            new Rectangle(150, 52, 16, 32)
        };

        private const int millisecondsPerFrame = 100;

        public LeftRunningBigLuigiSprite(Texture2D texture)
        {
            spriteDrawer = new SpriteDrawer(texture, sourceFrames, millisecondsPerFrame);
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
