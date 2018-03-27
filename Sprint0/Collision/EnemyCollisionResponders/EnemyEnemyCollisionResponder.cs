using Microsoft.Xna.Framework;
using SuperMarioBrothers.Entities.Enemies;

namespace SuperMarioBrothers.Collision.EnemyCollisionResponders
{
    public class EnemyEnemyCollisionResponder
    {
        public EnemyEnemyCollisionResponder()
        {
        }

        public void HandleCollision(IEnemy enemy, IEnemy enemy2, Side side)
        {
            int enemyHeight = enemy.DestinationRectangle.Height;
            int enemyWidth = enemy.DestinationRectangle.Width;

            Rectangle enemyRectangle = enemy.DestinationRectangle;
            Rectangle enemy2Rectangle = enemy2.DestinationRectangle;
            Rectangle intersect = Rectangle.Intersect(enemyRectangle, enemy2Rectangle);

            switch (side)
            {
                case (Side.Right):
                    {
                        if (enemy2.IsShell)
                        {
                            enemy.GetLaunched();
                            MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.EnemyLaunchScore(enemyRectangle.X, enemyRectangle.Y, true);
                        }
                        else if (!enemy.IsStomped && !enemy.IsLaunched && !enemy.IsShell)
                        {
                            enemy.DestinationRectangle = new Rectangle(enemyRectangle.X + intersect.Width, enemyRectangle.Y, enemyWidth, enemyHeight);
                            enemy.ChangeMovementDirection();
                        }

                        break;
                    }
                case (Side.Left):
                    {
                        if (enemy2.IsShell)
                        {
                            enemy.GetLaunched();
                            MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.EnemyLaunchScore(enemyRectangle.X, enemyRectangle.Y, true);
                        }
                        else if (!enemy.IsStomped && !enemy.IsLaunched && !enemy.IsShell)
                        {
                            enemy.DestinationRectangle = new Rectangle(enemyRectangle.X - intersect.Width, enemyRectangle.Y, enemyWidth, enemyHeight);
                            enemy.ChangeMovementDirection();
                        }

                        break;
                    }
                case (Side.Top):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y - intersect.Height, enemyWidth, enemyHeight);
                        break;
                    }
                case (Side.TopRight):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y - intersect.Height, enemyWidth, enemyHeight);
                        break;
                    }
                case (Side.TopLeft):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y - intersect.Height, enemyWidth, enemyHeight);
                        break;
                    }
                case (Side.Bottom):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y + intersect.Height, enemyWidth, enemyHeight);
                        break;
                    }
                case (Side.BottomRight):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y + intersect.Height, enemyWidth, enemyHeight);
                        break;
                    }
                case (Side.BottomLeft):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y + intersect.Height, enemyWidth, enemyHeight);
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


