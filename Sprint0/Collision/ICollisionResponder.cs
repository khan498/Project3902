using System.Collections.Generic;

namespace SuperMarioBrothers.Collision
{
    public interface ICollisionResponder
    {
        void HandleCollisions(List<ICollision> collisions);
    }
}
