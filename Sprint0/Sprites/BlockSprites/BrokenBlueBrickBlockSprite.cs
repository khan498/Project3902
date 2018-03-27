using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.BlockSprites
{
    class BrokenBlueBrickBlockSprite : ISprite
    {
        private Texture2D texture;
        private int timeSinceLastFrame = 0;
        private int currentFrame = 0;
        private int framesPerAnimation;

        private const int millisecondsPerFrame = 150;

        private static Rectangle[] sourceFrames = {
            new Rectangle(481, 13, 24, 24),
            new Rectangle(481, 37, 24, 24),
            new Rectangle(481, 67, 24, 24)
        };

        public BrokenBlueBrickBlockSprite(Texture2D spriteSheet)
        {
            texture = spriteSheet;
            framesPerAnimation = sourceFrames.Length;
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame && currentFrame < framesPerAnimation - 1)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                currentFrame++;
            }
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceFrames[currentFrame], color);
            spriteBatch.End();
        }
    }
}