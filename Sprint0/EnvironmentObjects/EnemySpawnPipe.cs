using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.EnvironmentObjects
{
    class EnemySpawnPipe : AbstractEnvironmentObject
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;

        private const int width = DataLibrary.DEFAULT_SIZE;
        private const int height = DataLibrary.DEFAULT_SIZE;

        public EnemySpawnPipe(Vector2 currentLocation, int scale = DataLibrary.PIPE_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetSmallPipeSprite();
            destinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, width * scale, height * scale);
        }

        public override ISprite CurrentSprite
        {
            get
            {
                return currentSprite;
            }

            set
            {
                currentSprite = value;
            }
        }

        public override Rectangle DestinationRectangle
        {
            get
            {
                return destinationRectangle;
            }

            set
            {
                destinationRectangle = value;
            }
        }

        public override void Update(GameTime gameTime)
        {
            CurrentSprite.Update(gameTime);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector)
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

            CurrentSprite.Draw(spriteBatch, offsetRectangle, Color.Red);
        }
    }
}
