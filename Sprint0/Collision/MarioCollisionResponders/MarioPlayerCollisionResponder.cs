using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Sounds;
using SuperMarioBrothers.GameMetrics;

namespace SuperMarioBrothers.Collision.MarioCollisionResponders
{
    public class MarioPlayerCollisionResponder
    {
        public MarioPlayerCollisionResponder()
        {
        }

        public void HandleCollision(IPlayer mario, IPlayer player, Side side)
        {
            GameScore gameScore = MarioGame.Instance.CurrentGameMode.GameMetric.GameScore;
            Rectangle marioRectangle = mario.DestinationRectangle;
            Rectangle enemyPlayerRectangle = player.DestinationRectangle;
            Rectangle position = enemyPlayerRectangle;
            if (mario is StarMario)
            {
                if (player.IsMarioBig())
                {
                    gameScore.EnemyLaunchScore(enemyPlayerRectangle.X, enemyPlayerRectangle.Y, false);
                }
                player.TakeDamage();
            }
            else
            {
                int marioHeight = mario.DestinationRectangle.Height;
                int marioWidth = mario.DestinationRectangle.Width;


                Rectangle intersect = Rectangle.Intersect(marioRectangle, enemyPlayerRectangle);

                switch (side)
                {
                    case (Side.Top):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X, marioRectangle.Y - intersect.Height, marioWidth, marioHeight);



                            player.TakeDamage();
                            mario.JumpEnable = true;
                            mario.UpMovement();

                            gameScore.EnemyStompScore(enemyPlayerRectangle.X, enemyPlayerRectangle.Y, mario.HitEnemyLast);

                            break;
                        }
                    case (Side.TopRight):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X + intersect.Width, marioRectangle.Y - intersect.Height, marioWidth, marioHeight);



                            player.TakeDamage();
                            mario.JumpEnable = true;
                            mario.UpMovement();

                            gameScore.EnemyStompScore(enemyPlayerRectangle.X, enemyPlayerRectangle.Y, mario.HitEnemyLast);
                            mario.HitEnemyLast = true;
                            break;
                        }
                    case (Side.TopLeft):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X - intersect.Width, marioRectangle.Y - intersect.Height, marioWidth, marioHeight);


                            player.TakeDamage();
                            mario.JumpEnable = true;
                            mario.UpMovement();

                            gameScore.EnemyStompScore(enemyPlayerRectangle.X, enemyPlayerRectangle.Y, mario.HitEnemyLast);

                            break;
                        }
                    case (Side.Right):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X + intersect.Width, marioRectangle.Y, marioWidth, marioHeight);

                            break;
                        }
                    case (Side.Left):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X - intersect.Width, marioRectangle.Y, marioWidth, marioHeight);

                            //player.DestinationRectangle = position;

                            break;
                        }

                    case (Side.Bottom):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X, marioRectangle.Y + intersect.Height, marioWidth, marioHeight);
                            mario.TakeDamage();
                            player.UpMovement();
                            player.JumpEnable = true;

                            gameScore.EnemyStompScore(enemyPlayerRectangle.X, enemyPlayerRectangle.Y, mario.HitEnemyLast);
                            break;
                        }
                    case (Side.BottomRight):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X + intersect.Width, marioRectangle.Y + intersect.Height, marioWidth, marioHeight);


                            break;
                        }
                    case (Side.BottomLeft):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X - intersect.Width, marioRectangle.Y + intersect.Height, marioWidth, marioHeight);


                            break;
                        }
                    case (Side.NotSpecified):
                        {
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
}
