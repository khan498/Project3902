using Microsoft.Xna.Framework;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Blocks
{
    public class QuestionBlock: AbstractBlock
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;

        private const int width = DataLibrary.DEFAULT_SIZE;
        private const int height = DataLibrary.DEFAULT_SIZE;

        private BlockBumpAnimator blockBumpAnimator;

        public QuestionBlock(Vector2 currentLocation, int scale = DataLibrary.BLOCK_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetQuestionBlockSprite();
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
        }
    }
}
