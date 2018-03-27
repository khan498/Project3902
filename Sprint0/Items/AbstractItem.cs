using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Items
{
    public abstract class AbstractItem : IItem
    {
        public enum MovementDirection
        {
            LEFT,
            RIGHT
        }
        public abstract Rectangle DestinationRectangle { get; set; }
        public abstract ISprite CurrentSprite { get; set; }
        public abstract bool IsActivated { get; set; }
        public abstract bool IsTransparent { get; set; }

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
            
            if (IsTransparent)
            {
                CurrentSprite.Draw(spriteBatch, offsetRectangle, Color.Transparent);
            }
            else
            {
                CurrentSprite.Draw(spriteBatch, offsetRectangle, Color.White);
            }
        }

        public abstract void ChangeMovementDirection();

        public abstract void RiseUp();

        public abstract void Update(GameTime gameTime);

        public abstract void NormalForce();

        public abstract void Move();

        public abstract void BounceUp();
    }
}
