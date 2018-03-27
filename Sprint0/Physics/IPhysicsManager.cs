using SuperMarioBrothers.Projectile;

namespace SuperMarioBrothers.Physics
{
    public interface IPhysicsManager
    {
        void ApplyPhysics(IProjectile projectile);
    }
}
