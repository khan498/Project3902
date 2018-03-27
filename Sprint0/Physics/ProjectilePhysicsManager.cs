using Microsoft.Xna.Framework;
using SuperMarioBrothers.Projectile;

namespace SuperMarioBrothers.Physics
{
    public class ProjectilePhysicsManager : IPhysicsManager
    {
        private static Vector2 gravityVelocity = new Vector2(0, 4);
        private static Vector2 minimumVelocity = new Vector2(0, 0);

        public ProjectilePhysicsManager()
        {
            Initialize();
        }

        private void Initialize()
        {
            
        }

        public void ApplyPhysics(IProjectile projectile)
        {
            ApplyGravity(projectile);
        }

        private void Move(IProjectile projectile)
        {
            projectile.Location = Vector2.Add(projectile.Location, projectile.Velocity);
        }

        private void ApplyGravity(IProjectile projectile)
        {
            projectile.Velocity = Vector2.Add(projectile.Velocity, gravityVelocity);

            if (projectile.Velocity.Y >= gravityVelocity.Y)
            {
                projectile.Velocity = new Vector2(projectile.Velocity.X, gravityVelocity.Y);
            }
        }
    }
}
