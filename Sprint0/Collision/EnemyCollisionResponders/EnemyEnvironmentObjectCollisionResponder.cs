using Microsoft.Xna.Framework;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.EnvironmentObjects;

namespace SuperMarioBrothers.Collision.EnemyCollisionResponders
{
    public class EnemyEnvironmentObjectCollisionResponder
    {
	    public EnemyEnvironmentObjectCollisionResponder()
	    {
	    }

        public void HandleCollision(IEnemy enemy, IEnvironmentObject environmentObject, Side side)
        {

            Rectangle enemyRectangle = enemy.DestinationRectangle;
            Rectangle pipeRectangle = environmentObject.DestinationRectangle;
            Rectangle intersect = Rectangle.Intersect(enemyRectangle, pipeRectangle);

            int height = enemy.DestinationRectangle.Height;
            int width = enemy.DestinationRectangle.Width;

            switch (side)
            {
                case (Side.Right):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X + intersect.Width, enemyRectangle.Y, width, height);
                        enemy.ChangeMovementDirection();
                        break;
                    }
                case (Side.Left):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X - intersect.Width, enemyRectangle.Y, width, height);
                        enemy.ChangeMovementDirection();
                        break;
                    }
                case (Side.Top):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y - intersect.Height, width, height);
                        break;
                    }
                case (Side.Bottom):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X, enemyRectangle.Y + intersect.Height, width, height);
                        break;
                    }
                case (Side.TopLeft):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X - intersect.Width, enemyRectangle.Y - intersect.Height, width, height);
                        break;
                    }
                case (Side.TopRight):
                    {
                        enemy.DestinationRectangle = new Rectangle(enemyRectangle.X + intersect.Width, enemyRectangle.Y - intersect.Height, width, height);
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


