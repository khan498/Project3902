using Microsoft.Xna.Framework;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Items;

namespace SuperMarioBrothers.Collision.ItemCollisionResponders
{
    public class ItemBlockCollisionResponder
    {
        public ItemBlockCollisionResponder()
        {
        }

        public void HandleCollision(IItem item, IBlock block, Side side)
        {
            Rectangle itemBoundingRectangle = item.DestinationRectangle;
            Rectangle blockBoundingRectangle = block.DestinationRectangle;
            Rectangle intersectRectangle = Rectangle.Intersect(itemBoundingRectangle, blockBoundingRectangle);

            int height = item.DestinationRectangle.Height;
            int width = item.DestinationRectangle.Width;

            switch (side)
            {
                case (Side.Top):
                    {
                        item.DestinationRectangle = new Rectangle(itemBoundingRectangle.X, itemBoundingRectangle.Y - intersectRectangle.Height, width, height);
                        item.NormalForce();
                        if(item is Star)
                        {
                            item.BounceUp();
                        }
                        break;
                    }
                case (Side.Bottom):
                    {
                        item.DestinationRectangle = new Rectangle(itemBoundingRectangle.X, itemBoundingRectangle.Y + intersectRectangle.Height, width, height);
                        item.NormalForce();
                        break;
                    }
                case (Side.Left):
                    {
                        item.DestinationRectangle = new Rectangle(itemBoundingRectangle.X - intersectRectangle.Width, itemBoundingRectangle.Y, width, height);
                        if ((!(block is SolidBlock1)) || (block is SolidBlock2))
                        {
                            item.ChangeMovementDirection();
                        }
                        item.Move();
                        item.NormalForce();
                        break;
                    }
                case (Side.Right):
                    {
                        item.DestinationRectangle = new Rectangle(itemBoundingRectangle.X + intersectRectangle.Width, itemBoundingRectangle.Y, width, height);
                        if ((!(block is SolidBlock1)) || (block is SolidBlock2))
                        {
                            item.ChangeMovementDirection();
                        }
                        item.Move();
                        item.NormalForce();
                        break;
                    }
                case (Side.TopLeft):
                    {
                        item.DestinationRectangle = new Rectangle(itemBoundingRectangle.X, itemBoundingRectangle.Y - intersectRectangle.Height, width, height);
                        item.NormalForce();
                        if (item is Star)
                        {
                            item.BounceUp();
                        }
                        break;
                    }
                case (Side.TopRight):
                    {
                        item.DestinationRectangle = new Rectangle(itemBoundingRectangle.X, itemBoundingRectangle.Y - intersectRectangle.Height, width, height);
                        item.NormalForce();
                        if (item is Star)
                        {
                            item.BounceUp();
                        }
                        break;
                    }
                case (Side.BottomLeft):
                    {
                        item.DestinationRectangle = new Rectangle(itemBoundingRectangle.X, itemBoundingRectangle.Y + intersectRectangle.Height, width, height);
                        item.NormalForce();
                        break;
                    }
                case (Side.BottomRight):
                    {
                        item.DestinationRectangle = new Rectangle(itemBoundingRectangle.X, itemBoundingRectangle.Y + intersectRectangle.Height, width, height);
                        item.NormalForce();
                        break;
                    }
                case (Side.NotSpecified):
                    {
                        item.NormalForce();
                        break;
                    }
                default:
                    {
                        break;
                    }
            }
        }
    }
}
