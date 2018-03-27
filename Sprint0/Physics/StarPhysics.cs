using Microsoft.Xna.Framework;
using SuperMarioBrothers.Items;
using SuperMarioBrothers.Level_Files;
using System;

namespace SuperMarioBrothers.Physics
{
    class StarPhysics : IPhysics
    {
        int gravity = DataLibrary.DEFAULT_GRAVITY;
        int maxVelocity = 10;

        IItem item;
        Rectangle movementRectangle;
        private Vector2 velocity = new Vector2(0, 0);
        public Boolean g = false;
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

        public StarPhysics(IItem item)
        {
            this.item = item;
        }


        public void MoveLeft()
        {
            velocity.X = -2;
        }
        public void RunLeft()
        {
            velocity.X = -4;
        }

        public void MoveRight()
        {
            velocity.X = 2;
        }
        public void RunRight()
        {
            velocity.X = 4;
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
        public void bounceUp()
        {
            velocity.Y = -15;
        }
        public void Update(Rectangle destinationRectangle)
        {
            movementRectangle = item.DestinationRectangle;
            if (g)
            {
                Gravity();
            }
            movementRectangle.X += (int)velocity.X;
            movementRectangle.Y += (int)velocity.Y;
            item.DestinationRectangle = movementRectangle;

        }
    }
}

