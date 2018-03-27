using Microsoft.Xna.Framework;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Projectile;

namespace SuperMarioBrothers.Physics
{
    public class FireBallPhysics : IPhysics
    {
        private const int gravity = DataLibrary.DEFAULT_GRAVITY;
        private const int maxVelocity = 10;
        private const int xVelocity = 4;
        private const int bounceVelocity = -10;

        FireBall_old fireBall;
        Rectangle movementRectangle;
        private Vector2 velocity = new Vector2(0, 0);

        public Vector2 Velocity
        {
            get { return velocity; }
            set { velocity = value; }
        }

        public FireBallPhysics(FireBall_old fireBall)
        {
            this.fireBall = fireBall;
        }

        public void MoveLeft()
        {
            velocity.X = -(xVelocity);
        }

        public void MoveRight()
        {
            velocity.X = xVelocity;
        }

        public void Bounce()
        {
            if (fireBall.BounceEnable)
            {
                velocity.Y = bounceVelocity;
                fireBall.BounceEnable = false;
            }
        }

        public void NormalForce()
        {
            //No-Op
            velocity.Y = 0;
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
            if (!fireBall.Exploding)
            {
                movementRectangle = fireBall.DestinationRectangle;
                Gravity();
                movementRectangle.X += (int)velocity.X;
                movementRectangle.Y += (int)velocity.Y;

                fireBall.DestinationRectangle = movementRectangle;
            }
        }
    }
}
