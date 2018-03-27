using SuperMarioBrothers.Levels;
using SuperMarioBrothers.Projectile;

namespace SuperMarioBrothers.Collision.CollisionDetectors
{
    public class ProjectileCollisionDetector
    {
        private FireBallCollisionDetector fireBallCollisionDetector;


        public ProjectileCollisionDetector()
        {
            Initialize();
        }

        public void DetectCollisions(ILevel level)
        {
            DetectAllCollisions(level);
        }

        private void Initialize()
        {
            fireBallCollisionDetector = new FireBallCollisionDetector();
        }

        private void DetectAllCollisions(ILevel level)
        {
            foreach (IProjectile projectile in level.Projectiles)
            {
                if (projectile is FireBall)
                {
                    fireBallCollisionDetector.DetectCollisions(level, (FireBall) projectile);
                }
            }
        }
    }
}
