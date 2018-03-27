using Microsoft.Xna.Framework;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Sounds;
using SuperMarioBrothers.GameMetrics;

namespace SuperMarioBrothers.Collision.MarioCollisionResponders
{
    public class MarioEnemyCollisionResponder
    {
        public MarioEnemyCollisionResponder()
        {
        }

        public void HandleCollision(IPlayer mario, IEnemy enemy, Side side)
        {
            GameScore gameScore = MarioGame.Instance.CurrentGameMode.GameMetric.GameScore;
            Rectangle marioRectangle = mario.DestinationRectangle;
            Rectangle enemyRectangle = enemy.DestinationRectangle;
            if (mario is StarMario)
            {
                if (!enemy.IsLaunched)
                {
                    SoundFactory.Instance.KickSound();
                    enemy.GetLaunched();
                    gameScore.EnemyLaunchScore(enemyRectangle.X, enemyRectangle.Y, false);
                }
            }
            else
            {
                int marioHeight = mario.DestinationRectangle.Height;
                int marioWidth = mario.DestinationRectangle.Width;


                Rectangle intersect = Rectangle.Intersect(marioRectangle, enemyRectangle);

                switch (side)
                {
                    case (Side.Top):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X, marioRectangle.Y - intersect.Height, marioWidth, marioHeight);

                            if (!enemy.IsStomped && !enemy.IsLaunched)
                            {
                                if (enemy is GreenKoopa)
                                {
                                    GreenKoopa koopa = (GreenKoopa)enemy;
                                    if ((koopa.IsShell) && (koopa.stable))
                                    {
                                        koopa.MovingFast = true;
                                        SoundFactory.Instance.KickSound();
                                    }
                                    else if ((koopa.IsShell) && (!koopa.stable))
                                    {
                                        koopa.stable = true;
                                        koopa.GetStomped();
                                    }
                                    else if (!koopa.IsShell)
                                    {
                                        koopa.GetStomped();
                                        SoundFactory.Instance.StompedSound();
                                    }

                                }
                                else if (enemy is Goomba)
                                {
                                    SoundFactory.Instance.StompedSound();
                                    enemy.GetStomped();
                                }
                            }
                            mario.JumpEnable = true;
                            gameScore.EnemyStompScore(enemyRectangle.X, enemyRectangle.Y, mario.HitEnemyLast);
                            mario.HitEnemyLast = true;
                            mario.UpMovement();
                            break;
                        }
                    case (Side.TopRight):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X + intersect.Width, marioRectangle.Y - intersect.Height, marioWidth, marioHeight);

                            if (!enemy.IsStomped && !enemy.IsLaunched)
                            {
                                if (enemy is GreenKoopa)
                                {
                                    GreenKoopa koopa = (GreenKoopa)enemy;
                                    if ((koopa.IsShell) && (koopa.stable))
                                    {
                                        koopa.MovingFast = true;
                                        SoundFactory.Instance.KickSound();
                                    }
                                    else if ((koopa.IsShell) && (!koopa.stable))
                                    {
                                        koopa.stable = true;
                                        koopa.GetStomped();
                                    }
                                    else if (!koopa.IsShell)
                                    {
                                        koopa.GetStomped();
                                        SoundFactory.Instance.StompedSound();
                                    }

                                }
                                else if (enemy is Goomba)
                                {
                                    SoundFactory.Instance.StompedSound();
                                    enemy.GetStomped();
                                }
                            }
                            mario.JumpEnable = true;
                            gameScore.EnemyStompScore(enemyRectangle.X, enemyRectangle.Y, mario.HitEnemyLast);
                            mario.HitEnemyLast = true;
                            mario.UpMovement();
                            break;
                        }
                    case (Side.TopLeft):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X - intersect.Width, marioRectangle.Y - intersect.Height, marioWidth, marioHeight);

                            if (!enemy.IsStomped && !enemy.IsLaunched)
                            {
                                if (enemy is GreenKoopa)
                                {
                                    GreenKoopa koopa = (GreenKoopa)enemy;
                                    if ((koopa.IsShell) && (koopa.stable))
                                    {
                                        koopa.MovingFast = true;
                                        SoundFactory.Instance.KickSound();
                                    }
                                    else if ((koopa.IsShell) && (!koopa.stable))
                                    {
                                        koopa.stable = true;
                                        koopa.GetStomped();
                                    }
                                    else if (!koopa.IsShell)
                                    {
                                        koopa.GetStomped();
                                        SoundFactory.Instance.StompedSound();
                                    }

                                }
                                else if (enemy is Goomba)
                                {
                                    SoundFactory.Instance.StompedSound();
                                    enemy.GetStomped();
                                }
                            }
                            mario.JumpEnable = true;
                            gameScore.EnemyStompScore(enemyRectangle.X, enemyRectangle.Y, mario.HitEnemyLast);
                            mario.HitEnemyLast = true;
                            mario.UpMovement();
                            break;
                        }
                    case (Side.Right):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X + intersect.Width, marioRectangle.Y, marioWidth, marioHeight);

                            if (!enemy.IsStomped && !enemy.IsLaunched)
                            {
                                if (enemy is GreenKoopa)
                                {
                                    GreenKoopa koopa = (GreenKoopa)enemy;
                                    if ((koopa.IsShell) && (koopa.stable))
                                    {
                                        koopa.MovingFast = true;
                                        SoundFactory.Instance.KickSound();
                                    }
                                    else if ((koopa.IsShell) && (!koopa.stable))
                                    {
                                        mario.TakeDamage();
                                    }
                                    else if (!koopa.IsShell)
                                    {
                                        mario.TakeDamage();
                                    }

                                }
                                else if (enemy is Goomba)
                                {
                                    mario.TakeDamage();
                                }
                            }
                            break;
                        }
                    case (Side.Left):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X - intersect.Width, marioRectangle.Y, marioWidth, marioHeight);
                            if (!enemy.IsStomped && !enemy.IsLaunched)
                            {
                                if(enemy is GreenKoopa)
                                {
                                    GreenKoopa koopa = (GreenKoopa)enemy;
                                    if ((koopa.IsShell) && (koopa.stable))
                                    {
                                        koopa.MovingFast = true;
                                        SoundFactory.Instance.KickSound();
                                    }
                                    else if ((koopa.IsShell) && (!koopa.stable))
                                    {
                                        mario.TakeDamage();
                                    }else if (!koopa.IsShell)
                                    {
                                        mario.TakeDamage();
                                    }
                                   
                                }else if(enemy is Goomba)
                                {
                                    mario.TakeDamage();
                                }

                                
                            }
                            break;
                        }

                    case (Side.Bottom):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X, marioRectangle.Y + intersect.Height, marioWidth, marioHeight);

                            if (!enemy.IsStomped && !enemy.IsLaunched)
                            {
                                mario.TakeDamage();
                            }
                            break;
                        }
                    case (Side.BottomRight):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X + intersect.Width, marioRectangle.Y + intersect.Height, marioWidth, marioHeight);

                            if (!enemy.IsStomped && !enemy.IsLaunched)
                            {
                                mario.TakeDamage();
                            }
                            break;
                        }
                    case (Side.BottomLeft):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X - intersect.Width, marioRectangle.Y + intersect.Height, marioWidth, marioHeight);

                            if (!enemy.IsStomped && !enemy.IsLaunched)
                            {
                                mario.TakeDamage();
                            }
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


