using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.EnvironmentObjects
{
    class LongPipe : AbstractEnvironmentObject
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;

        private const int width = DataLibrary.DEFAULT_SIZE * 2;
        private const int height = DataLibrary.DEFAULT_SIZE * 4;

        public LongPipe(Vector2 currentLocation, int scale = DataLibrary.PIPE_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetLongPipeSprite();
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
