using Microsoft.Xna.Framework;
using SuperMarioBrothers.Entities.Mario;

namespace SuperMarioBrothers.Warps
{
    public interface IWarp
    {
        Vector2 Location { get; }

        void Warp(IPlayer player);
    }
}
