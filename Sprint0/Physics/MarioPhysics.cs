using Microsoft.Xna.Framework;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Level_Files;

namespace SuperMarioBrothers.Physics
{
    public class MarioPhysics : IPhysics
    {

        int gravity = DataLibrary.DEFAULT_GRAVITY;
        int maxVelocity = 15;

        int jumpVelocity = -18;
        IPlayer mario;
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
        public MarioPhysics(IPlayer mario)
        {          
            this.mario = mario;          
        }
        public void Jump()
        {
            if (mario.JumpEnable)
            {
                velocity.Y = jumpVelocity;
                mario.JumpEnable = false;
            }
 
        }
        public void MoveLeft()
        {
            velocity.X = -3;
        }
        public void RunLeft()
        {
            velocity.X = -6;
        }
        public void MoveRight()
        {
            velocity.X = 3;
        }
        public void RunRight()
        {
            velocity.X = 6;
        }
        public void BeIdle()
        {
            velocity.X = 0;
        }
        public void NormalForce()
        {
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
            movementRectangle = mario.DestinationRectangle;
            Gravity();
            movementRectangle.X += (int)velocity.X;
            movementRectangle.Y += (int)velocity.Y;
            mario.DestinationRectangle = movementRectangle;

        }
    }
}
