using Microsoft.Xna.Framework;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Sprites;
using SuperMarioBrothers.Sprites.BlockSprites;

namespace SuperMarioBrothers.Blocks
{
    public class BlueBrickBlock : AbstractBlock
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;

        private const int width = DataLibrary.DEFAULT_SIZE;
        private const int height = DataLibrary.DEFAULT_SIZE;

        private BlockBumpAnimator blockBumpAnimator;
        private int elapsedTime = 0;
        private const int brokenBlockTimer = 550;

        public BlueBrickBlock(Vector2 currentLocation, int scale = DataLibrary.BLOCK_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetBlueBrickBlockSprite();
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
            destinationRectangle = new Rectangle(destinationRectangle.X - DataLibrary.BRICK_BLOCK_OFFSET, 
                destinationRectangle.Y - DataLibrary.BRICK_BLOCK_OFFSET, 
                destinationRectangle.Width + DataLibrary.BRICK_BLOCK_OFFSET, 
                destinationRectangle.Height + DataLibrary.BRICK_BLOCK_OFFSET);
            currentSprite = SpriteFactory.Instance.GetBrokenBrickBlockSprite();
            IsBumped = true;
            IgnoreCollision = true;
            IsRemovable = false;
        }
    }
}
