using Microsoft.Xna.Framework;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Sprites;
using SuperMarioBrothers.Sprites.BlockSprites;

namespace SuperMarioBrothers.Blocks
{
    public class BrickBlock : AbstractBlock
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;

        private const int width = DataLibrary.DEFAULT_SIZE;
        private const int height = DataLibrary.DEFAULT_SIZE;

        private BlockBumpAnimator blockBumpAnimator;
        private int elapsedTime = 0;
        private const int brokenBlockTimer = 550;

        public BrickBlock(Vector2 currentLocation, int scale = DataLibrary.BLOCK_SCALE)
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

        public override Rectangle DestinationRectangle
        {
            get { return destinationRectangle; }
            set { destinationRectangle = value; }
        }
        
        public override void Update(GameTime gameTime)
        {
            blockBumpAnimator.Animate();
            CurrentSprite.Update(gameTime);

            if (currentSprite is BrokenBrickBlockSprite)
            {
                elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
                if (elapsedTime > brokenBlockTimer)
                {
                    IsRemovable = true;
                }
            }
        }

        public override void BreakBlock()
        {
            destinationRectangle = new Rectangle(destinationRectangle.X - 12, destinationRectangle.Y - 12, destinationRectangle.Width + 12, destinationRectangle.Height + 12);
            currentSprite = SpriteFactory.Instance.GetBrokenBrickBlockSprite();
            IsBumped = true;
            IgnoreCollision = true;
            IsRemovable = false;
        }
    }
}
