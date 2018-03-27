using Microsoft.Xna.Framework;

namespace SuperMarioBrothers.Collision
{
    public interface ICollision
    {
        Rectangle OverlapRectangle { get; }
        Side Side { get; }
        int OverlapArea { get; }
    }
}
