using Microsoft.Xna.Framework;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Level_Files;

namespace SuperMarioBrothers.Physics
{
    public class EnemyPhysics : IPhysics
    {
        int gravity = DataLibrary.DEFAULT_GRAVITY;
        int maxVelocity = 10;

        IEnemy enemy;
        Rectangle movementRectangle;
        private Vector2 velocity = new Vector2(0, 0);
        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }
            set
            {
                velocity = value;
            }
        }

        public EnemyPhysics(IEnemy enemy)
        {          
            this.enemy = enemy;          
        }


        public void MoveLeft()
        {
            velocity.X = -1;
        }

        public void MoveRight()
        {
            velocity.X = 1;
        }

        public void FastLeft()
        {
            velocity.X = -3;
        }

        public void FastRight()
        {
            velocity.X = 3;
        }

        public void BeIdle()
        {
            velocity.X = 0;
        }
        public void NormalForce()
        {
            velocity.Y = 0;
        }

        public void LaunchPhysics()
        {
            velocity.Y = -10;
            velocity.X = 4;
        }

        public void Gravity()
        {
            if (velocity.Y < maxVelocity)
            {
                velocity.Y += gravity;
            }
        }

        public void Update(Rectangle destinationRectangle)
        {
            movementRectangle = enemy.DestinationRectangle;
            Gravity();
            movementRectangle.X += (int)velocity.X;
            movementRectangle.Y += (int)velocity.Y;
            enemy.DestinationRectangle = movementRectangle;

        }
    }
}
