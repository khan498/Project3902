using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Entities.Enemies
{
    public interface IEnemy
    {
        Vector2 CurrentLocation { get; set; }

        Rectangle DestinationRectangle { get; set; }

        ISprite CurrentSprite { get; set; }

        bool IsStomped { get; set; }

        bool IsLaunched { get; set; }

        bool IsActivated { get; set; }
        bool IsShell { get; set; }

        void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector);
        void Update(GameTime gameTime);

        void GetStomped();

        void GetLaunched();

        void NormalForce();

        void ChangeMovementDirection();

    }
}
