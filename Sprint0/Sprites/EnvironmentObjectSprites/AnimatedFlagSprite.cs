using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.EnvironmentObjectSprites
{
    class AnimatedFlagSprite : ISprite
    {
        private Texture2D texture;
        private int timeSinceLastFrame = 0;
        private int currentFrame = 0;
        private int framesPerAnimation;

        private const int millisecondsPerFrame = 150;

        private static Rectangle[] sourceFrames = {
            new Rectangle(241, 594, 32, 168),
            new Rectangle(208, 594, 32, 168),
            new Rectangle(174, 594, 32, 168),
            new Rectangle(141, 594, 32, 168),
            new Rectangle(108, 594, 32, 168)
        };

        public AnimatedFlagSprite(Texture2D spriteSheet)
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
