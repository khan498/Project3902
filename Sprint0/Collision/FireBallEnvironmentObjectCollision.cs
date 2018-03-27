using Microsoft.Xna.Framework;
using SuperMarioBrothers.EnvironmentObjects;
using SuperMarioBrothers.Projectile;

namespace SuperMarioBrothers.Collision
{
    public class FireBallEnvironmentObjectCollision
    {
        private FireBall fireBall;
        private IEnvironmentObject envObj;

        private Rectangle overlapRectangle;
        private Side side;

        public FireBall FireBall
        {
            get
            {
                return fireBall;
            }
        }

        public IEnvironmentObject EnvironmentObject
        {
            get
            {
                return envObj;
            }
        }

        public Side Side
        {
            get
            {
                return side;
            }
        }

        public Rectangle OverlapRectangle
        {
            get
            {
                return overlapRectangle;
            }
        }

        private FireBallEnvironmentObjectCollision()
        {
        }

        public FireBallEnvironmentObjectCollision(FireBall fireBall, IEnvironmentObject envObj, Rectangle overlapRectangle, Side side)
        {
            this.fireBall = fireBall;
            this.envObj = envObj;

            this.overlapRectangle = overlapRectangle;
            this.side = side;
        }
    }
}
