using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Projectile;

namespace SuperMarioBrothers.Collision
{
    public class FireBallPlayerCollision
    {
        private FireBall fireBall;
        private IPlayer player;

        public FireBall FireBall
        {
            get
            {
                return fireBall;
            }
        }

        public IPlayer Player
        {
            get
            {
                return player;
            }
        }

        private FireBallPlayerCollision()
        {
        }

        public FireBallPlayerCollision(FireBall fireBall, IPlayer player)
        {
            this.fireBall = fireBall;
            this.player = player;
        }
    }
}
