using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Levels;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Entities.Mario
{
    public interface IPlayer
    {

        Rectangle DestinationRectangle { get; set; }
        ISprite CurrentSprite { get; set; }
        Vector2 VelocityVector { get; }
        Vector2 CurrentLocationVector { get; set; }
        bool IsIdle { get; }
        int Width { get; }
        bool RunActivated { get; set; }
        bool JumpEnable { get; set; }
        bool CanGoInPipe { get; set; } 

        bool IsMario { get; set; }
        bool IsMovingDown { get; set; }
        bool IsMovingRight { get; set; }

        bool IsInvincible { get; set; }
        bool IsInAnimation { get; set; }
        //ILevel CurrentLevel { get; set; }
        bool IsCrouching { get; }

        bool HitEnemyLast { get; set; }

        void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector);

        void Update(GameTime gameTime);

        void TakeDamage();

        void BeDead();

        void BeSmall();

        void BeBig();

        void BeFire();

        void UpMovement();

        void DownMovement();

        void LeftMovement();

        void RightMovement();

        void BeIdle();
        void NormalForce();
        bool IsMarioSmall();

        bool IsMarioBig();

        bool IsMarioFire();

        bool IsMarioDead();

        bool IsFacingRight();
        void Dead();

        void AddLives(int lives);
        int GetRemainingLives();
    }
}
