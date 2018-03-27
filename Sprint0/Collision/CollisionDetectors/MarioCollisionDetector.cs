using Microsoft.Xna.Framework;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Collision;
using SuperMarioBrothers.Collision.MarioCollisionResponders;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.EnvironmentObjects;
using SuperMarioBrothers.Items;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Levels;
using System.Diagnostics;

namespace SuperMarioBrothers.CollisionDectorAndResponder.Collision.CollisionDetectors
{
    public class MarioCollisionDetector
    {
        private const int COIN_OFFSET = DataLibrary.COIN_OFFSET;
        public MarioCollisionDetector()
        {

        }

        public void DetectCollisions(ILevel level, IPlayer mario)
        {
            Rectangle marioBoundingRectangle = mario.DestinationRectangle;

            foreach (IPlayer player in level.Players)
            {
                if (((mario.IsMario) && (!player.IsMario)) || ((!mario.IsMario) && (player.IsMario)))
                {


                    Rectangle enemyPlayerBoundingRectangle = player.DestinationRectangle;
                    Rectangle overlapRectangle = Rectangle.Intersect(marioBoundingRectangle, enemyPlayerBoundingRectangle);
                    if (!overlapRectangle.IsEmpty)
                    {
                        Side side = Side.NotSpecified;
                        if (overlapRectangle.Width > overlapRectangle.Height)
                        {
                            if (marioBoundingRectangle.Y <= enemyPlayerBoundingRectangle.Y)
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

                            if (marioBoundingRectangle.X <= enemyPlayerBoundingRectangle.X && marioBoundingRectangle.Y <= enemyPlayerBoundingRectangle.Y)
                            {
                                side = Side.TopLeft;
                            }
                            else if (marioBoundingRectangle.X >= enemyPlayerBoundingRectangle.X && marioBoundingRectangle.Y <= enemyPlayerBoundingRectangle.Y)
                            {
                                side = Side.TopRight;
                            }
                            else if (marioBoundingRectangle.X >= enemyPlayerBoundingRectangle.X && marioBoundingRectangle.Y >= enemyPlayerBoundingRectangle.Y)
                            {
                                side = Side.BottomRight;
                            }
                            else if (marioBoundingRectangle.X <= enemyPlayerBoundingRectangle.X && marioBoundingRectangle.Y >= enemyPlayerBoundingRectangle.Y)
                            {
                                side = Side.BottomLeft;
                            }
                        }
                        else if (overlapRectangle.Height > overlapRectangle.Width)
                        {
                            if (marioBoundingRectangle.X <= enemyPlayerBoundingRectangle.X)
                            {
                                side = Side.Left;
                            }
                            else
                            {
                                side = Side.Right;
                            }
                        }
                        if ((!mario.IsMarioDead()) && (!player.IsMarioDead()) && (!player.IsInvincible))
                        {
                            new MarioPlayerCollisionResponder().HandleCollision(mario, player, side);
                        }
                    }
                }
            }

            #region Items


            foreach (IItem item in level.Items.ToArray())
            {
                Rectangle itemBoundingRectangle = item.DestinationRectangle;

                if (item is Coin)
                {
                    itemBoundingRectangle.X -= COIN_OFFSET;
                    itemBoundingRectangle.Width += COIN_OFFSET;
                }

                Rectangle overlapRectangle = Rectangle.Intersect(marioBoundingRectangle, itemBoundingRectangle);

                if (!overlapRectangle.IsEmpty)
                {
                    Side side = Side.NotSpecified;
                    if (overlapRectangle.Width > overlapRectangle.Height)
                    {
                        if (marioBoundingRectangle.Y <= itemBoundingRectangle.Y)
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

                        if (marioBoundingRectangle.X <= itemBoundingRectangle.X && marioBoundingRectangle.Y <= itemBoundingRectangle.Y)
                        {
                            side = Side.TopLeft;
                        }
                        else if (marioBoundingRectangle.X >= itemBoundingRectangle.X && marioBoundingRectangle.Y <= itemBoundingRectangle.Y)
                        {
                            side = Side.TopRight;
                        }
                        else if (marioBoundingRectangle.X >= itemBoundingRectangle.X && marioBoundingRectangle.Y >= itemBoundingRectangle.Y)
                        {
                            side = Side.BottomRight;
                        }
                        else if (marioBoundingRectangle.X <= itemBoundingRectangle.X && marioBoundingRectangle.Y >= itemBoundingRectangle.Y)
                        {
                            side = Side.BottomLeft;
                        }
                    }
                    else if (overlapRectangle.Height > overlapRectangle.Width)
                    {
                        if (marioBoundingRectangle.X <= itemBoundingRectangle.X)
                        {
                            side = Side.Left;
                        }
                        else
                        {
                            side = Side.Right;
                        }
                    }
                    new MarioItemCollisionResponder().HandleCollision(mario, item, side, level.Items);
                }
            }

            #endregion Items
            #region Enemies

            foreach (IEnemy enemy in level.Enemies)
            {
                Rectangle enemyBoundingRectangle = enemy.DestinationRectangle;
                Rectangle overlapRectangle = Rectangle.Intersect(marioBoundingRectangle, enemyBoundingRectangle);

                if (!overlapRectangle.IsEmpty && !enemy.IsStomped)
                {
                    Side side = Side.NotSpecified;

                    if (overlapRectangle.Height > overlapRectangle.Width)
                    {
                        if (marioBoundingRectangle.X <= enemyBoundingRectangle.X)
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
                        if (marioBoundingRectangle.Y <= enemyBoundingRectangle.Y)
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
                        if (marioBoundingRectangle.X <= enemyBoundingRectangle.X && marioBoundingRectangle.Y >= enemyBoundingRectangle.Y)
                        {
                            side = Side.BottomLeft;
                        }
                        else if (marioBoundingRectangle.X <= enemyBoundingRectangle.X && marioBoundingRectangle.Y <= enemyBoundingRectangle.Y)
                        {
                            side = Side.TopLeft;
                        }
                        else if (marioBoundingRectangle.X >= enemyBoundingRectangle.X && marioBoundingRectangle.Y >= enemyBoundingRectangle.Y)
                        {
                            side = Side.BottomRight;
                        }
                        else if (marioBoundingRectangle.X >= enemyBoundingRectangle.X && marioBoundingRectangle.Y <= enemyBoundingRectangle.Y)
                        {
                            side = Side.TopRight;
                        }
                    }

                    if (!mario.IsMarioDead())
                    {
                        new MarioEnemyCollisionResponder().HandleCollision(mario, enemy, side);
                    }

                }
            }

            #endregion Enemies

            #region Blocks

            foreach (IBlock block in level.Blocks.ToArray())
            {
                Rectangle blockBoundingRectangle = block.DestinationRectangle;
                Rectangle overlapRectangle = Rectangle.Intersect(marioBoundingRectangle, blockBoundingRectangle);

                if (!overlapRectangle.IsEmpty)
                {

                    Side side = Side.NotSpecified;
                    if (overlapRectangle.Width > overlapRectangle.Height)
                    {
                        if (marioBoundingRectangle.Y <= blockBoundingRectangle.Y)
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

                        if (marioBoundingRectangle.X <= blockBoundingRectangle.X && marioBoundingRectangle.Y <= blockBoundingRectangle.Y)
                        {
                            side = Side.TopLeft;
                        }
                        else if (marioBoundingRectangle.X >= blockBoundingRectangle.X && marioBoundingRectangle.Y <= blockBoundingRectangle.Y)
                        {
                            side = Side.TopRight;
                        }
                        else if (marioBoundingRectangle.X >= blockBoundingRectangle.X && marioBoundingRectangle.Y >= blockBoundingRectangle.Y)
                        {
                            side = Side.BottomRight;
                        }
                        else if (marioBoundingRectangle.X <= blockBoundingRectangle.X && marioBoundingRectangle.Y >= blockBoundingRectangle.Y)
                        {
                            side = Side.BottomLeft;
                        }
                    }
                    else if (overlapRectangle.Height > overlapRectangle.Width)
                    {
                        if (marioBoundingRectangle.X <= blockBoundingRectangle.X)
                        {
                            side = Side.Left;
                        }
                        else
                        {
                            side = Side.Right;
                        }
                    }

                    if (!mario.IsMarioDead())
                    {
                        new MarioBlockCollisionResponder().HandleCollision(mario, block, side, level.Blocks);
                    }

                }

            }


            #endregion Blocks

            #region EnvironmentObjects

            foreach (IEnvironmentObject environmentObject in level.EnvironmentObjects)
            {
                Rectangle environmentObjectBoundingRectangle = environmentObject.DestinationRectangle;
                Rectangle overlapRectangle = Rectangle.Intersect(marioBoundingRectangle, environmentObjectBoundingRectangle);

                if (!overlapRectangle.IsEmpty && !environmentObject.IgnoreCollision)
                {
                    Side side = Side.NotSpecified;

                    if (overlapRectangle.Height > overlapRectangle.Width)
                    {
                        if (marioBoundingRectangle.X <= environmentObjectBoundingRectangle.X)
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
                        if (marioBoundingRectangle.Y <= environmentObjectBoundingRectangle.Y)
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
                        if (marioBoundingRectangle.X <= environmentObjectBoundingRectangle.X && marioBoundingRectangle.Y >= environmentObjectBoundingRectangle.Y)
                        {
                            side = Side.BottomLeft;
                        }
                        else if (marioBoundingRectangle.X <= environmentObjectBoundingRectangle.X && marioBoundingRectangle.Y <= environmentObjectBoundingRectangle.Y)
                        {
                            side = Side.TopLeft;
                        }
                        else if (marioBoundingRectangle.X >= environmentObjectBoundingRectangle.X && marioBoundingRectangle.Y >= environmentObjectBoundingRectangle.Y)
                        {
                            side = Side.BottomRight;
                        }
                        else if (marioBoundingRectangle.X >= environmentObjectBoundingRectangle.X && marioBoundingRectangle.Y <= environmentObjectBoundingRectangle.Y)
                        {
                            side = Side.TopRight;
                        }
                    }
                    if (!mario.IsMarioDead())
                    {
                        new MarioEnvironmentObjectCollisionResponder().HandleCollision(mario, environmentObject, side);
                    }
                }
            }
        }

        #endregion EnvironmentObjects
    }

}
