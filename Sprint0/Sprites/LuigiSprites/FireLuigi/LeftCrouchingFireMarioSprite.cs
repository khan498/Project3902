using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.LuigiSprites.FireLuigi
{
    class LeftCrouchingFireLuigiSprite : ISprite
    {
        private const int millisecondsPerFrame = 0;

        private static Rectangle[] sourceFrames = {
            new Rectangle(0, 127, 16,22)
        };

        private SpriteDrawer spriteDrawer;

        public LeftCrouchingFireLuigiSprite(Texture2D spriteSheet)
        {
            spriteDrawer = new SpriteDrawer(spriteSheet, sourceFrames, millisecondsPerFrame);
        }

        public void Update(GameTime gameTime)
        {
           // Not animated
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {
   

            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }
    }
}

