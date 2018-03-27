using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.BlockSprites
{
    class QuestionBlockSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;
        private const int millisecondsPerFrame = 150;
        
        private static Rectangle[] sourceFrames = {
            new Rectangle(372, 160, 16, 16),
            new Rectangle(390, 160, 16, 16),
            new Rectangle(408, 160, 16, 16),
            new Rectangle(372, 179, 16, 16),
            new Rectangle(390, 179, 16, 16),
            new Rectangle(408, 179, 16, 16)
        };
        
        public QuestionBlockSprite(Texture2D texture)
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
