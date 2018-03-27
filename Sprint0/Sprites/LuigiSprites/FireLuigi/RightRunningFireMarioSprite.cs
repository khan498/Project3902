using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.LuigiSprites.FireLuigi
{
    class RightRunningFireLuigiSprite : ISprite
    {
        private const int millisecondsPerFrame = 100;

        private static Rectangle[] sourceFrames = {
            new Rectangle(287, 123, 16, 30),
            new Rectangle(263, 122, 14, 31),
            new Rectangle(237, 122, 16, 32)
        };

        private SpriteDrawer spriteDrawer;

        public RightRunningFireLuigiSprite(Texture2D spriteSheet)
        {
            spriteDrawer = new SpriteDrawer(spriteSheet, sourceFrames, millisecondsPerFrame);
        }

        public void Update(GameTime gameTime)
        {
            spriteDrawer.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle,Color color)
        {


            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }
    }
}
