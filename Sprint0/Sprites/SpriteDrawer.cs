using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites
{
    class SpriteDrawer
    {
        private Texture2D texture;
        private Rectangle[] sourceFrames;
        private int timeSinceLastFrame = 0;
        private int millisecondsPerFrame;
        private int currentFrame = 0;
        private int framesPerAnimation;

        public SpriteDrawer(Texture2D texture, Rectangle[] sourceFrames, int millisecondsPerFrame)
        {
            this.texture = texture;
            this.sourceFrames = sourceFrames;
            this.millisecondsPerFrame = millisecondsPerFrame;
            framesPerAnimation = sourceFrames.Length;
        }

        public void Update(GameTime gameTime)
        {
            timeSinceLastFrame += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastFrame > millisecondsPerFrame)
            {
                timeSinceLastFrame -= millisecondsPerFrame;
                currentFrame++;
                if (currentFrame == framesPerAnimation)
                    currentFrame = 0;
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
