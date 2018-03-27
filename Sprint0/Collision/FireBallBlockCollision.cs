using Microsoft.Xna.Framework;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Projectile;

namespace SuperMarioBrothers.Collision
{
    public class FireBallBlockCollision : ICollision
    {
        private Rectangle overlapRectangle;
        private Side side;

        private FireBall fireBall;
        private IBlock block;

        public Rectangle OverlapRectangle
        {
            get
            {
                return overlapRectangle;
            }
        }

        public Side Side
        {
            get
            {
                return side;
            }
        }

        public int OverlapArea
        {
            get
            {
                return OverlapRectangle.Width * OverlapRectangle.Height;
            }
        }

        public FireBall FireBall
        {
            get
            {
                return fireBall;
            }
        }

        public IBlock Block
        {
            get
            {
                return block;
            }
        }

        public FireBallBlockCollision()
        {
            overlapRectangle = new Rectangle();
            side = Side.NotSpecified;
        }

        public FireBallBlockCollision(FireBall fireBall, IBlock block, Rectangle overlapRectangle, Side side)
        {
            this.fireBall = fireBall;
            this.block = block;
            this.overlapRectangle = overlapRectangle;
            this.side = side;
        }
    }
}
