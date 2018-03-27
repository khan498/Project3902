using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioBrothers.Sprites.LuigiSprites.BigLuigi
{
    class LeftCrouchingBigLuigiSprite : ISprite
    {
        private const int millisecondsPerFrame = 0;
        private SpriteDrawer spriteDrawer;

        private static Rectangle[] sourceFrames = {
            new Rectangle(0, 57 , 16, 22)
        };

        public LeftCrouchingBigLuigiSprite(Texture2D texture)
        {
            spriteDrawer = new SpriteDrawer(texture, sourceFrames, millisecondsPerFrame);
        }

        public void Update(GameTime gameTime)
        {
            //not animated
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {

            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }
    }
}
