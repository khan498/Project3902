using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Levels;

namespace SuperMarioBrothers.Camera
{
    public interface ICamera
    {
        Vector2 TopLeftWorldSpace { get; set; }
        Vector2 OffsetVector { get; }
        Vector2 Center { get; }
        bool IsAtLeftEdgeOfLevel { get; }
        bool IsAtRightEdgeOfLevel { get; }
        int LeftBoundaryX { get; }
        int RightBoundaryX { get; }
        ILevel CurrentLevel { get; set; }

        int Width { get; set; }
        int Height { get; set; }

        void Update();
        void Draw(SpriteBatch spriteBatch);

        void ScrollLeft(int pixelsToScroll);

        void ScrollRight(int pixelsToScroll);
    }
}
