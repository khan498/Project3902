using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Projectile;
using System.Collections.Generic;
using SuperMarioBrothers.Sounds;

namespace SuperMarioBrothers.Collision.FireBallCollisionResponder
{
    public class FireBallEnemyCollisionResponder
    {
        public FireBallEnemyCollisionResponder()
        {
        }

        public void HandleCollisions(List<FireBallEnemyCollision> collisions)
        {
            foreach (FireBallEnemyCollision collision in collisions)
            {
                HandleCollision(collision);
            }
        }

        private void HandleCollision(FireBallEnemyCollision collision)
        {
            if (!collision.Enemy.IsStomped)
            {
                if (!collision.Enemy.IsLaunched)
                {
                    SoundFactory.Instance.KickSound();
                    collision.Enemy.GetLaunched();
                    MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.EnemyLaunchScore(collision.Enemy.DestinationRectangle.X, collision.Enemy.DestinationRectangle.Y, false);
                }

                collision.FireBall.Explode();
            }
        }

        public void HandleCollision(FireBall_old fireBall, IEnemy enemy, List<FireBall_old> fireBalls)
        {
            if (!enemy.IsStomped && !enemy.IsLaunched)
            {
                fireBall.Explode();
                enemy.GetLaunched();              
            }
        }

    }
}
