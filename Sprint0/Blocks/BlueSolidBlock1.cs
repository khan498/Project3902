using Microsoft.Xna.Framework;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Blocks
{
    class BlueSolidBlock1 : AbstractBlock
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;

        private const int width = DataLibrary.DEFAULT_SIZE;
        private const int height = DataLibrary.DEFAULT_SIZE;

        public BlueSolidBlock1(Vector2 currentLocation, int scale = DataLibrary.BLOCK_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetBlueSolidBlock1Sprite();
            destinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, width * scale, height * scale);
        }

        public override ISprite CurrentSprite
        {
            get { return currentSprite; }
            set { currentSprite = value; }
        }

        public override Rectangle DestinationRectangle
        {
            get { return destinationRectangle; }
            set { destinationRectangle = value; }
        }

        public override void Update(GameTime gameTime)
        {
            CurrentSprite.Update(gameTime);
        }
    }
}

