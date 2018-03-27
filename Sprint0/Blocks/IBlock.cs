using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Blocks
{
    public interface IBlock
    {
        Rectangle DestinationRectangle { get; set; }
        ISprite CurrentSprite { get; set; }
        bool IsBumped { get; set; }
        bool IsRemovable { get; set; }
        bool IgnoreCollision { get; set; }

        void Bump();
        void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector);
        void Update(GameTime gameTime);
        void BreakBlock();
    }
}
