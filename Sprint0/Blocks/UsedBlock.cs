using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using SuperMarioBrothers.Sprites;
using SuperMarioBrothers.Level_Files;

namespace SuperMarioBrothers.Blocks
{
    class UsedBlock: AbstractBlock
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;

        private const int width = DataLibrary.DEFAULT_SIZE;
        private const int height = DataLibrary.DEFAULT_SIZE;

        public UsedBlock(Vector2 currentLocation, int scale = DataLibrary.BLOCK_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetUsedBlockSprite();
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
