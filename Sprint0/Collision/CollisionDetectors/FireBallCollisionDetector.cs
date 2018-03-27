using Microsoft.Xna.Framework;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Collision.FireBallCollisionResponder;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.EnvironmentObjects;
using SuperMarioBrothers.GameModes;
using SuperMarioBrothers.Levels;
using SuperMarioBrothers.Projectile;
using System.Collections.Generic;

namespace SuperMarioBrothers.Collision.CollisionDetectors
{
    public class FireBallCollisionDetector
    {
        private FireBallBlockCollisionResponder fireBallBlockCollisionResponder;
        private FireBallEnemyCollisionResponder fireBallEnemyCollisionResponder;
        private FireBallEnvironmentCollisionResponder envResponder;
        private FireBallPlayerCollisionResponder fireBallPlayerCollisionResponder;


        public FireBallCollisionDetector()
        {
            Initialize();
        }

        public void DetectCollisions(ILevel level, FireBall fireBall)
        {
            List<ICollision> blockCollisions = new List<ICollision>();
            List<FireBallEnemyCollision> enemyCollisions = new List<FireBallEnemyCollision>();
            List<FireBallEnvironmentObjectCollision> envCollisions = new List<FireBallEnvironmentObjectCollision>();
            List<FireBallPlayerCollision> playerCollisions = new List<FireBallPlayerCollision>();

            Rectangle fireBallBoundingRectangle = new Rectangle(
                (int)fireBall.Location.X,
                (int)fireBall.Location.Y,
                fireBall.Width,
                fireBall.Height
            );

            #region Enemies

            foreach (IEnemy enemy in level.Enemies)
            {
                Rectangle enemyBoundingRectangle = enemy.DestinationRectangle;

                if (fireBallBoundingRectangle.Intersects(enemyBoundingRectangle))
                {
                    enemyCollisions.Add(new FireBallEnemyCollision(fireBall, enemy));
                }
            }
            #endregion Enemies

            #region Blocks

            foreach (IBlock block in level.Blocks)
            {

                Rectangle blockBoundingRectangle = block.DestinationRectangle;
                Rectangle overlapRectangle = Rectangle.Intersect(fireBallBoundingRectangle, blockBoundingRectangle);

                if (!overlapRectangle.IsEmpty)
                {
                    Side side = Side.NotSpecified;
                    if (overlapRectangle.Width > overlapRectangle.Height)
                    {
                        if (fireBallBoundingRectangle.Y <= blockBoundingRectangle.Y)
                        {
                            side = Side.Top;
                        }
                        else
                        {
                            side = Side.Bottom;
                        }
                    }
                    else if (overlapRectangle.Height > overlapRectangle.Width)
                    {
                        if (fireBallBoundingRectangle.X <= blockBoundingRectangle.X)
                        {
                            side = Side.Left;
                        }
                        else
                        {
                            side = Side.Right;
                        }
                    }
                    else if (overlapRectangle.Width == overlapRectangle.Height)
                    {
                        if (fireBallBoundingRectangle.X <= blockBoundingRectangle.X && fireBallBoundingRectangle.Y <= blockBoundingRectangle.Y)
                        {
                            side = Side.TopLeft;
                        }
                        else if (fireBallBoundingRectangle.X >= blockBoundingRectangle.X && fireBallBoundingRectangle.Y <= blockBoundingRectangle.Y)
                        {
                            side = Side.TopRight;
                        }
                        else if (fireBallBoundingRectangle.X >= blockBoundingRectangle.X && fireBallBoundingRectangle.Y >= blockBoundingRectangle.Y)
                        {
                            side = Side.BottomRight;
                        }
                        else if (fireBallBoundingRectangle.X <= blockBoundingRectangle.X && fireBallBoundingRectangle.Y >= blockBoundingRectangle.Y)
                        {
                            side = Side.BottomLeft;
                        }
                    }

                    blockCollisions.Add(new FireBallBlockCollision(fireBall, block, overlapRectangle, side));
                }
            }
            #endregion Blocks

            #region EnvironmentObjects

            foreach (IEnvironmentObject environmentObject in level.EnvironmentObjects)
            {
                Rectangle environmentOnjectRectangle = environmentObject.DestinationRectangle;
                Rectangle overlapRectangle = Rectangle.Intersect(fireBallBoundingRectangle, environmentOnjectRectangle);

                if (!overlapRectangle.IsEmpty)
                {

                    Side side = Side.NotSpecified;

                    if (overlapRectangle.Width > overlapRectangle.Height)
                    {
                        if (fireBallBoundingRectangle.Y <= environmentOnjectRectangle.Y)
                        {
                            side = Side.Top;
                        }
                        else
                        {
                            side = Side.Bottom;
                        }
                    }
                    else if (overlapRectangle.Height > overlapRectangle.Width)
                    {
                        if (fireBallBoundingRectangle.X <= environmentOnjectRectangle.X)
                        {
                            side = Side.Left;
                        }
                        else
                        {
                            side = Side.Right;
                        }
                    }
                    else if (overlapRectangle.Width == overlapRectangle.Height)
                    {
                        if (fireBallBoundingRectangle.X <= environmentOnjectRectangle.X && fireBallBoundingRectangle.Y <= environmentOnjectRectangle.Y)
                        {
                            side = Side.TopLeft;
                        }
                        else if (fireBallBoundingRectangle.X >= environmentOnjectRectangle.X && fireBallBoundingRectangle.Y <= environmentOnjectRectangle.Y)
                        {
                            side = Side.TopRight;
                        }
                        else if (fireBallBoundingRectangle.X >= environmentOnjectRectangle.X && fireBallBoundingRectangle.Y >= environmentOnjectRectangle.Y)
                        {
                            side = Side.BottomRight;
                        }
                        else if (fireBallBoundingRectangle.X <= environmentOnjectRectangle.X && fireBallBoundingRectangle.Y >= environmentOnjectRectangle.Y)
                        {
                            side = Side.BottomLeft;
                        }
                    }

                    envCollisions.Add(new FireBallEnvironmentObjectCollision(
                            fireBall, 
                            environmentObject, 
                            overlapRectangle, 
                            side
                    ));
                    //new FireBallEnvironmentCollisionResponder().HandleCollision(fireBall, environmentObject, side, level.FireBalls);
                }
            }
            #endregion EnvironmentObjects

            #region Player
            foreach (IPlayer player in level.Players)
            {
                Rectangle enemyPlayerBoundingRectangle = player.DestinationRectangle;

                if (fireBallBoundingRectangle.Intersects(enemyPlayerBoundingRectangle))
                {
                    playerCollisions.Add(new FireBallPlayerCollision(fireBall, player));
                }
            }
            #endregion Player

            fireBallBlockCollisionResponder.HandleCollisions(blockCollisions);
            fireBallEnemyCollisionResponder.HandleCollisions(enemyCollisions);
            if (MarioGame.Instance.CurrentGameMode is ArenaGameMode)
            {
                fireBallPlayerCollisionResponder.HandleCollisions(playerCollisions);
            }
            envResponder.HandleCollisions(envCollisions);
        }

        private void Initialize()
        {
            fireBallBlockCollisionResponder = new FireBallBlockCollisionResponder();
            fireBallEnemyCollisionResponder = new FireBallEnemyCollisionResponder();
            fireBallPlayerCollisionResponder = new FireBallPlayerCollisionResponder();
            envResponder = new FireBallEnvironmentCollisionResponder();
        }
    }
}
