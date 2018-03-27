using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Blocks
{
    public abstract class AbstractBlock : IBlock
    {
        public virtual Rectangle DestinationRectangle { get; set; }
        public abstract ISprite CurrentSprite { get; set; }

        private bool isBumped = false;
        private bool isRemovable = false;
        private bool ignoreCollision = false;

        public virtual bool IsBumped
        {
            get { return isBumped; }
            set { isBumped = value; }
        }

        public virtual bool IsRemovable
        {
            get { return isRemovable; }
            set { isRemovable = value; }
        }

        public virtual bool IgnoreCollision
        {
            get { return ignoreCollision; }
            set { ignoreCollision = value; }
        }

        public virtual void Bump()
        {
            isBumped = true;
        }

        public virtual void BreakBlock()
        {
            // No-Op
        }

        public virtual void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector)
        {
            Vector2 destRectVector = new Vector2(
                DestinationRectangle.X,
                DestinationRectangle.Y
            );
            Vector2 offsetVector = Vector2.Subtract(destRectVector, cameraOffsetVector);
            Rectangle offsetRectangle = new Rectangle(
                (int)offsetVector.X,
                (int)offsetVector.Y,
                DestinationRectangle.Width,
                DestinationRectangle.Height
            );

            CurrentSprite.Draw(spriteBatch, offsetRectangle, Color.White);
        }

        public virtual void Update(GameTime gameTime)
        {
            CurrentSprite.Update(gameTime);
        }
    }
}
