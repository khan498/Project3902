using Microsoft.Xna.Framework;
using SuperMarioBrothers.EnvironmentObjects;
using SuperMarioBrothers.Items;

namespace SuperMarioBrothers.Collision.ItemCollisionResponders
{
    public class ItemEnvironmentCollisionResponder
    {
        public ItemEnvironmentCollisionResponder()
        {
        }

        public void HandleCollision(IItem item, IEnvironmentObject environmentObject, Side side)
        {
            Rectangle itemBoundingRectangle = item.DestinationRectangle;
            Rectangle envObjBoundingRectangle = environmentObject.DestinationRectangle;
            Rectangle intersectRectangle = Rectangle.Intersect(itemBoundingRectangle, envObjBoundingRectangle);

            int height = item.DestinationRectangle.Height;
            int width = item.DestinationRectangle.Width;

            switch (side)
            {
                case (Side.Top):
                    {
                        item.DestinationRectangle = new Rectangle(itemBoundingRectangle.X, itemBoundingRectangle.Y - intersectRectangle.Height, width, height);
                        item.NormalForce();
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
                        item.ChangeMovementDirection();
                        item.Move();
                        item.NormalForce();
                        break;
                    }
                case (Side.Right):
                    {
                        item.DestinationRectangle = new Rectangle(itemBoundingRectangle.X - intersectRectangle.Width, itemBoundingRectangle.Y, width, height);
                        item.ChangeMovementDirection();
                        item.Move();
                        item.NormalForce();
                        break;
                    }
                case (Side.TopLeft):
                    {
                        item.DestinationRectangle = new Rectangle(itemBoundingRectangle.X, itemBoundingRectangle.Y - intersectRectangle.Height, width, height);
                        item.NormalForce();
                        break;
                    }
                case (Side.TopRight):
                    {
                        item.DestinationRectangle = new Rectangle(itemBoundingRectangle.X, itemBoundingRectangle.Y - intersectRectangle.Height, width, height);
                        item.NormalForce();
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
