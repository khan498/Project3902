using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Projectile
{
    public interface IProjectile
    {
        bool IsActive { get; set; }
        Vector2 Velocity { get; set; }
        Vector2 Location { get; set; }
        int Width { get; }
        int Height { get; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector);
    }
}
