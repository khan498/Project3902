using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.LuigiSprites.FireLuigi
{
    class LeftRunningFireLuigiSprite : ISprite
    {
        private const int millisecondsPerFrame = 100;

        private static Rectangle[] sourceFrames = {
            new Rectangle(102, 123, 16, 30),
            new Rectangle(128, 122, 14, 31),
            new Rectangle(152, 122, 16, 32)
        };

        private SpriteDrawer spriteDrawer;

        public LeftRunningFireLuigiSprite(Texture2D spriteSheet)
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
