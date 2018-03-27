using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Projectile;

namespace SuperMarioBrothers.Collision
{
    public class FireBallEnemyCollision
    {
        private FireBall fireBall;
        private IEnemy enemy;

        public FireBall FireBall
        {
            get
            {
                return fireBall;
            }
        }

        public IEnemy Enemy
        {
            get
            {
                return enemy;
            }
        }

        private FireBallEnemyCollision()
        {
        }

        public FireBallEnemyCollision(FireBall fireBall, IEnemy enemy)
        {
            this.fireBall = fireBall;
            this.enemy = enemy;
        }
    }
}
