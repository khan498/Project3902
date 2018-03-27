using Microsoft.Xna.Framework;
using System.Collections.Generic;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Sounds;

namespace SuperMarioBrothers.Collision.EnemyCollisionResponders
{
    public class EnemyBlockCollisionResponder
    {
        public EnemyBlockCollisionResponder()
        {
        }

        public void HandleCollision(IEnemy enemy, IBlock block, Side side, List<IBlock> Blocks)
        {
            Rectangle enemyRectangle = enemy.DestinationRectangle;
            Rectangle blockRectangle = block.DestinationRectangle;
            Rectangle intersect = Rectangle.Intersect(enemyRectangle, blockRectangle);

            int height = enemy.DestinationRectangle.Height;
            int width = enemy.DestinationRectangle.Width;

            switch (side)
            {
                case (Side.Top):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y - intersect.Height, width, height);
                        enemy.NormalForce();
                        if (block.IsBumped || block.IgnoreCollision)
                        {
                            if (!enemy.IsLaunched)
                            {
                                SoundFactory.Instance.KickSound();
                                MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.EnemyLaunchScore(enemy.DestinationRectangle.X, enemy.DestinationRectangle.Y, false);
                                enemy.GetLaunched();
                            }
                            
                        }
                        break;
                    }
                case (Side.TopRight):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y - intersect.Height, width, height);
                        enemy.NormalForce();

                        if (block.IsBumped || block.IgnoreCollision)
                        {
                            if (!enemy.IsLaunched)
                            {
                                SoundFactory.Instance.KickSound();
                                MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.EnemyLaunchScore(enemy.DestinationRectangle.X, enemy.DestinationRectangle.Y, false);
                                enemy.GetLaunched();
                            }
                        }
                        break;
                    }
                case (Side.TopLeft):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y - intersect.Height, width, height);
                        enemy.NormalForce();
                        if (block.IsBumped || block.IgnoreCollision)
                        {
                            if (!enemy.IsLaunched)
                            {
                                SoundFactory.Instance.KickSound();
                                MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.EnemyLaunchScore(enemy.DestinationRectangle.X, enemy.DestinationRectangle.Y, false);
                                enemy.GetLaunched();
                            }
                        }

                        break;
                    }
                case (Side.Right):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X + intersect.Width, enemyRectangle.Y, width, height);
                        enemy.NormalForce();
                        enemy.ChangeMovementDirection();
                        if(enemy is GreenKoopa)
                        {
                            GreenKoopa koopa = (GreenKoopa)enemy;
                         
                            if (enemy.IsShell)
                            {
                                SoundFactory.Instance.BumpSound();
                            }
                            
                        }
                        break;
                    }
                case (Side.Left):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X - intersect.Width, enemyRectangle.Y, width, height);
                        enemy.NormalForce();
                        enemy.ChangeMovementDirection();
                        
                        if(enemy is GreenKoopa)
                        {
                            GreenKoopa koopa = (GreenKoopa)enemy;
                            if (enemy.IsShell)
                            {
                                SoundFactory.Instance.BumpSound();
                            }
                        }
                        break;
                    }

                case (Side.Bottom):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y + intersect.Height, width, height);
                        break;
                    }


                case (Side.BottomLeft):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X - intersect.Width, enemyRectangle.Y + intersect.Height, width, height);
                        break;
                    }
                case (Side.BottomRight):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X + intersect.Width, enemyRectangle.Y + intersect.Height, width, height);
                        break;
                    }
                case (Side.NotSpecified):
                    {
                        enemy.NormalForce();
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


