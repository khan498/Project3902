using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Items
{
    public interface IItem
    {
        Rectangle DestinationRectangle { get; set; }

        ISprite CurrentSprite { get; set; }

        bool IsActivated { get; set; }

        bool IsTransparent { get; set; }

        void RiseUp();

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector);

        void NormalForce();

        void ChangeMovementDirection();

        void Move();

        void BounceUp();

    }
}
