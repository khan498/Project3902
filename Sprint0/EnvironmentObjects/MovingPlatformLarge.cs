using Microsoft.Xna.Framework;
using SuperMarioBrothers.Sprites;
using System;

namespace SuperMarioBrothers.EnvironmentObjects
{
    public class MovingPlatformLarge : AbstractEnvironmentObject
    {
        private Vector2 location;
        private Vector2 velocity;

        private ISprite sprite;

        private int width = 3;
        private int height = 1;

        private int maxMovementRangeYPixels;
        private int pixelsMovedY;

        public MovingPlatformLarge(Vector2 start, int maxMovementRangeYPixels)
        {
            Initialize(start, maxMovementRangeYPixels);
        }

        public override Rectangle DestinationRectangle
        {
            get
            {
                return new Rectangle(
                    (int) location.X, 
                    (int) location.Y, 
                    width * 32,
                    height * 32
                );
            }

            set
            {
                location = new Vector2(value.X, value.Y);
            }
        }
        public override ISprite CurrentSprite
        {
            get { return sprite; }

            set { sprite = value; }
        }

        public override void Update(GameTime gameTime)
        {
            sprite.Update(gameTime);
            Move();
        }

        private void Initialize(Vector2 start, int maxMovementRangeYPixels)
        {
            location = start;
            sprite = SpriteFactory.Instance.GetMovingPlatformLargeSprite();
            this.maxMovementRangeYPixels = maxMovementRangeYPixels;

            velocity = new Vector2(0, -1);  // Initially move up
            pixelsMovedY = 0;
        }

        private void Move()
        {
            if (ShouldChangeDirection())
            {
                velocity = velocity * -1;
            }

            location = Vector2.Add(location, velocity);
            pixelsMovedY += Math.Abs((int) velocity.Y);
        }

        private bool ShouldChangeDirection()
        {
            bool shouldChangeDir = false;

            if (pixelsMovedY >= maxMovementRangeYPixels)
            {
                pixelsMovedY = 0;
                shouldChangeDir = true;
            }

            return shouldChangeDir;
        }
    }
}
