using Microsoft.Xna.Framework;

namespace SuperMarioBrothers.Blocks
{
    public class BlockBumpAnimator
    {
        private int maxBumpOffset;
        private int yCoordinate;

        private IBlock block;

        public BlockBumpAnimator(IBlock block)
        {
            this.block = block;
            yCoordinate = block.DestinationRectangle.Y;
            maxBumpOffset = yCoordinate - block.DestinationRectangle.Height / 4;
        }

        public void Animate()
        {
            if (block.IsBumped && block.DestinationRectangle.Y > maxBumpOffset)
            {
                block.DestinationRectangle = new Rectangle(block.DestinationRectangle.X, block.DestinationRectangle.Y - 2,
                    block.DestinationRectangle.Width, block.DestinationRectangle.Height);
            }
            else if (block.DestinationRectangle.Y <= maxBumpOffset)
            {
                block.IsBumped = false;
                block.DestinationRectangle = new Rectangle(block.DestinationRectangle.X, yCoordinate,
                    block.DestinationRectangle.Width, block.DestinationRectangle.Height);

                if (!(block is BrickBlock || block is SpecialBrickBlock))
                    block.IsRemovable = true;
            }
        }
    }
}
