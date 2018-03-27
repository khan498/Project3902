using Microsoft.Xna.Framework;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Collision.ItemCollisionResponders;
using SuperMarioBrothers.EnvironmentObjects;
using SuperMarioBrothers.Items;
using SuperMarioBrothers.Levels;

namespace SuperMarioBrothers.Collision.CollisionDetectors
{
    public class ItemCollisionDetector
    {
        public ItemCollisionDetector()
        {
        }

        public void DetectCollisions(ILevel level, IItem item)
        {
            Rectangle itemBoundingRectangle = item.DestinationRectangle;

            #region Blocks

            foreach (IBlock block in level.Blocks)
            {
                Rectangle blockBoundingRectangle = block.DestinationRectangle;
                Rectangle overlapRectangle = Rectangle.Intersect(itemBoundingRectangle, blockBoundingRectangle);

                if (!overlapRectangle.IsEmpty)
                {
                    Side side = Side.NotSpecified;
                    if (overlapRectangle.Width > overlapRectangle.Height)
                    {
                        if (itemBoundingRectangle.Y <= blockBoundingRectangle.Y)
                        {
                            side = Side.Top;
                        }
                        else
                        {
                            side = Side.Bottom;
                        }
                    }
                    else if (overlapRectangle.Width == overlapRectangle.Height)
                    {

                        if (itemBoundingRectangle.X <= blockBoundingRectangle.X && itemBoundingRectangle.Y <= blockBoundingRectangle.Y)
                        {
                            side = Side.TopLeft;
                        }
                        else if (itemBoundingRectangle.X >= blockBoundingRectangle.X && itemBoundingRectangle.Y <= blockBoundingRectangle.Y)
                        {
                            side = Side.TopRight;
                        }
                        else if (itemBoundingRectangle.X >= blockBoundingRectangle.X && itemBoundingRectangle.Y >= blockBoundingRectangle.Y)
                        {
                            side = Side.BottomRight;
                        }
                        else if (itemBoundingRectangle.X <= blockBoundingRectangle.X && itemBoundingRectangle.Y >= blockBoundingRectangle.Y)
                        {
                            side = Side.BottomLeft;
                        }
                    }
                    else if (overlapRectangle.Height > overlapRectangle.Width)
                    {
                        if (itemBoundingRectangle.X <= blockBoundingRectangle.X)
                        {
                            side = Side.Left;
                        }
                        else
                        {
                            side = Side.Right;
                        }
                    }
                    
                    if (item.IsActivated)
                    {
                        new ItemBlockCollisionResponder().HandleCollision(item, block, side);
                    }
                }
            }
            
            #endregion Blocks

            #region EnvironmentObjects

            foreach (IEnvironmentObject environmentObject in level.EnvironmentObjects)
            {
                Rectangle envObjBoundingRectangle = environmentObject.DestinationRectangle;
                Rectangle overlapRectangle = Rectangle.Intersect(itemBoundingRectangle, envObjBoundingRectangle);

                if (!overlapRectangle.IsEmpty)
                {
                    Side side = Side.NotSpecified;

                    if (overlapRectangle.Height > overlapRectangle.Width)
                    {
                        if (itemBoundingRectangle.X <= envObjBoundingRectangle.X)
                        {
                            side = Side.Left;
                        }
                        else
                        {
                            side = Side.Right;
                        }
                    }
                    else if (overlapRectangle.Width > overlapRectangle.Height)
                    {
                        if (itemBoundingRectangle.Y <= envObjBoundingRectangle.Y)
                        {
                            side = Side.Top;
                        }
                        else
                        {
                            side = Side.Bottom;
                        }
                    }
                    else if (overlapRectangle.Width == overlapRectangle.Height)
                    {
                        if (itemBoundingRectangle.X <= envObjBoundingRectangle.X && itemBoundingRectangle.Y >= envObjBoundingRectangle.Y)
                        {
                            side = Side.BottomLeft;
                        }
                        else if (itemBoundingRectangle.X <= envObjBoundingRectangle.X && itemBoundingRectangle.Y <= envObjBoundingRectangle.Y)
                        {
                            side = Side.TopLeft;
                        }
                        else if (itemBoundingRectangle.X >= envObjBoundingRectangle.X && itemBoundingRectangle.Y >= envObjBoundingRectangle.Y)
                        {
                            side = Side.BottomRight;
                        }
                        else if (itemBoundingRectangle.X >= envObjBoundingRectangle.X && itemBoundingRectangle.Y <= envObjBoundingRectangle.Y)
                        {
                            side = Side.TopRight;
                        }
                    }

                    new ItemEnvironmentCollisionResponder().HandleCollision(item, environmentObject, side);
                }
            }
        }

        #endregion EnvironmentObjects
    }
}
