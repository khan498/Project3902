using Microsoft.Xna.Framework;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Collision.EnemyCollisionResponders;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.EnvironmentObjects;
using SuperMarioBrothers.Items;
using SuperMarioBrothers.Levels;

namespace SuperMarioBrothers.Collision.CollisionDetectors
{
    public class EnemyCollisionDetector
    {
        public EnemyCollisionDetector()
        {

        }

        public void DetectCollisions(ILevel level, IEnemy enemy)
        {
            Rectangle enemyBoundingRectangle = enemy.DestinationRectangle;

            if (!enemy.IsLaunched)
            {
                #region Enemies

                foreach (IEnemy enemy2 in level.Enemies)
                {
                    if (enemy2 != enemy)
                    {
                        Rectangle enemy2BoundingRectangle = enemy2.DestinationRectangle;
                        Rectangle overlapRectangle = Rectangle.Intersect(enemyBoundingRectangle, enemy2BoundingRectangle);

                        if (!overlapRectangle.IsEmpty)
                        {
                            Side side = Side.NotSpecified;

                            if (overlapRectangle.Height > overlapRectangle.Width)
                            {
                                if (enemyBoundingRectangle.X <= enemy2BoundingRectangle.X)
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
                                if (enemyBoundingRectangle.Y <= enemy2BoundingRectangle.Y)
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
                                if (enemyBoundingRectangle.X <= enemy2BoundingRectangle.X && enemyBoundingRectangle.Y >= enemy2BoundingRectangle.Y)
                                {
                                    side = Side.BottomLeft;
                                }
                                else if (enemyBoundingRectangle.X <= enemy2BoundingRectangle.X && enemyBoundingRectangle.Y <= enemy2BoundingRectangle.Y)
                                {
                                    side = Side.TopLeft;
                                }
                                else if (enemyBoundingRectangle.X >= enemy2BoundingRectangle.X && enemyBoundingRectangle.Y >= enemy2BoundingRectangle.Y)
                                {
                                    side = Side.BottomRight;
                                }
                                else if (enemyBoundingRectangle.X >= enemy2BoundingRectangle.X && enemyBoundingRectangle.Y <= enemy2BoundingRectangle.Y)
                                {
                                    side = Side.TopRight;
                                }
                            }

                            new EnemyEnemyCollisionResponder().HandleCollision(enemy, enemy2, side);
                        }
                    }
                }

                #endregion Enemies

                #region Blocks

                foreach (IBlock block in level.Blocks.ToArray())
                {
                    Rectangle blockBoundingRectangle = block.DestinationRectangle;
                    Rectangle overlapRectangle = Rectangle.Intersect(enemyBoundingRectangle, blockBoundingRectangle);

                    if (!overlapRectangle.IsEmpty)
                    {

                        Side side = Side.NotSpecified;
                        if (overlapRectangle.Width > overlapRectangle.Height)
                        {
                            if (enemyBoundingRectangle.Y <= blockBoundingRectangle.Y)
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

                            if (enemyBoundingRectangle.X <= blockBoundingRectangle.X && enemyBoundingRectangle.Y <= blockBoundingRectangle.Y)
                            {
                                side = Side.TopLeft;
                            }
                            else if (enemyBoundingRectangle.X >= blockBoundingRectangle.X && enemyBoundingRectangle.Y <= blockBoundingRectangle.Y)
                            {
                                side = Side.TopRight;
                            }
                            else if (enemyBoundingRectangle.X >= blockBoundingRectangle.X && enemyBoundingRectangle.Y >= blockBoundingRectangle.Y)
                            {
                                side = Side.BottomRight;
                            }
                            else if (enemyBoundingRectangle.X <= blockBoundingRectangle.X && enemyBoundingRectangle.Y >= blockBoundingRectangle.Y)
                            {
                                side = Side.BottomLeft;
                            }
                        }
                        else if (overlapRectangle.Height > overlapRectangle.Width)
                        {
                            if (enemyBoundingRectangle.X <= blockBoundingRectangle.X)
                            {
                                side = Side.Left;
                            }
                            else
                            {
                                side = Side.Right;
                            }
                        }

                        new EnemyBlockCollisionResponder().HandleCollision(enemy, block, side, level.Blocks);
                    }
                }


                #endregion Blocks

                #region EnvironmentObjects

                foreach (IEnvironmentObject environmentObject in level.EnvironmentObjects)
                {
                    Rectangle environmentObjectBoundingRectangle = environmentObject.DestinationRectangle;
                    Rectangle overlapRectangle = Rectangle.Intersect(enemyBoundingRectangle, environmentObjectBoundingRectangle);

                    if (!overlapRectangle.IsEmpty)
                    {
                        Side side = Side.NotSpecified;

                        if (overlapRectangle.Height > overlapRectangle.Width)
                        {
                            if (enemyBoundingRectangle.X <= environmentObjectBoundingRectangle.X)
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
                            if (enemyBoundingRectangle.Y <= environmentObjectBoundingRectangle.Y)
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
                            if (enemyBoundingRectangle.X <= environmentObjectBoundingRectangle.X && enemyBoundingRectangle.Y >= environmentObjectBoundingRectangle.Y)
                            {
                                side = Side.BottomLeft;
                            }
                            else if (enemyBoundingRectangle.X <= environmentObjectBoundingRectangle.X && enemyBoundingRectangle.Y <= environmentObjectBoundingRectangle.Y)
                            {
                                side = Side.TopLeft;
                            }
                            else if (enemyBoundingRectangle.X >= environmentObjectBoundingRectangle.X && enemyBoundingRectangle.Y >= environmentObjectBoundingRectangle.Y)
                            {
                                side = Side.BottomRight;
                            }
                            else if (enemyBoundingRectangle.X >= environmentObjectBoundingRectangle.X && enemyBoundingRectangle.Y <= environmentObjectBoundingRectangle.Y)
                            {
                                side = Side.TopRight;
                            }
                        }

                        new EnemyEnvironmentObjectCollisionResponder().HandleCollision(enemy, environmentObject, side);
                    }
                }
            }

            #endregion EnvironmentObjects
        }
    }
}
