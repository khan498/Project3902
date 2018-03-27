using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Entities.Enemies
{
    public abstract class AbstractEnemy : IEnemy
    {
        public enum WalkingDirection
        {
            LEFT,
            RIGHT
        }
        public abstract Vector2 CurrentLocation { get; set; }
        public abstract Rectangle DestinationRectangle { get; set; }
        public abstract ISprite CurrentSprite { get; set; }
        public abstract bool IsStomped { get; set; }
        public abstract bool IsLaunched { get; set; }
        public abstract bool IsActivated { get; set; }
        public abstract bool IsShell { get; set; }

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
        public abstract void NormalForce();
        public abstract void Update(GameTime gameTime);
        public abstract void GetStomped();
        public abstract void GetLaunched();
        public abstract void ChangeMovementDirection();
    }
}
