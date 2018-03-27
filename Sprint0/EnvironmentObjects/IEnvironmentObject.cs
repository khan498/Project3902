using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.EnvironmentObjects
{
    public interface IEnvironmentObject
    {
        Rectangle DestinationRectangle { get; set; }

        ISprite CurrentSprite { get; set; }

        bool IgnoreCollision { get; set; }

        void Activate();

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector);
    }
}
