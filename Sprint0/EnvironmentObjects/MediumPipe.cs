using Microsoft.Xna.Framework;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.EnvironmentObjects
{
    class MediumPipe : AbstractEnvironmentObject
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;

        private const int width = DataLibrary.DEFAULT_SIZE * 2;
        private const int height = DataLibrary.DEFAULT_SIZE * 3;

        public MediumPipe(Vector2 currentLocation, int scale = DataLibrary.PIPE_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetMediumPipeSprite();
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
    }
}
