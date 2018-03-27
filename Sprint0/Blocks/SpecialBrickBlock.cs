using Microsoft.Xna.Framework;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Levels;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Blocks
{
    class SpecialBrickBlock : AbstractBlock
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;

        private const int width = DataLibrary.DEFAULT_SIZE;
        private const int height = DataLibrary.DEFAULT_SIZE;

        private int blockLives = 5;

        private BlockBumpAnimator blockBumpAnimator;

        public SpecialBrickBlock(Vector2 currentLocation, int scale = DataLibrary.BLOCK_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetBrickBlockSprite();
            destinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, width * scale, height * scale);

            blockBumpAnimator = new BlockBumpAnimator(this);
        }

        public override ISprite CurrentSprite
        {
            get { return currentSprite; }
            set { currentSprite = value; }
        }

        public override void Bump()
        {
            base.Bump();
            blockLives--;

            if (blockLives >= 1)
                MarioGame.Instance.CurrentGameMode.CurrentLevel.AddCoinInBlock(this);
        }

        public override Rectangle DestinationRectangle
        {
            get { return destinationRectangle; }
            set { destinationRectangle = value; }
        }

        public override void Update(GameTime gameTime)
        {
            blockBumpAnimator.Animate();

            if (blockLives <= 0)
                IsRemovable = true;

            CurrentSprite.Update(gameTime);
        }
    }
}
