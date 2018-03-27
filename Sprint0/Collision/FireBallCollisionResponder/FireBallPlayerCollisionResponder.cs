using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Projectile;
using System.Collections.Generic;
using SuperMarioBrothers.Sounds;

namespace SuperMarioBrothers.Collision.FireBallCollisionResponder
{
    public class FireBallPlayerCollisionResponder
    {
        public FireBallPlayerCollisionResponder()
        {
        }

        public void HandleCollisions(List<FireBallPlayerCollision> collisions)
        {
            foreach (FireBallPlayerCollision collision in collisions)
            {
                HandleCollision(collision);
            }
        }

        private void HandleCollision(FireBallPlayerCollision collision)
        {
            if (!collision.Player.IsMarioDead())
            {
               
                //SoundFactory.Instance.KickSound();
                if (!collision.Player.IsInvincible) {
                    collision.Player.TakeDamage();
                }
                //MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.EnemyLaunchScore(collision.Player.DestinationRectangle.X, collision.Player.DestinationRectangle.Y, false);
                
      
                collision.FireBall.Explode();
            }
        }

        public void HandleCollision(FireBall_old fireBall, IPlayer player, List<FireBall_old> fireBalls)
        {
            if (!player.IsMarioDead())
            {
                fireBall.Explode();
                player.TakeDamage();
            }
        }

    }
}
