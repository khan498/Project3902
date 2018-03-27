using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.EnvironmentObjects
{
    public abstract class AbstractEnvironmentObject : IEnvironmentObject
    {
        public abstract Rectangle DestinationRectangle { get; set; }
        public abstract ISprite CurrentSprite { get; set; }

        private bool ignoreCollision = false;

        public virtual bool IgnoreCollision
        {
            get { return ignoreCollision; }
            set { ignoreCollision = value; }
        }


        public virtual void Activate()
        {

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

        public abstract void Update(GameTime gameTime);
    }
}
