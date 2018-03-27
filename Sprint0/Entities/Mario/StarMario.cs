using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Sprites;
using SuperMarioBrothers.Sounds;
using Microsoft.Xna.Framework.Media;
using SuperMarioBrothers.Level_Files;

namespace SuperMarioBrothers.Entities.Mario
{
    public class StarMario : IPlayer
    {
        IPlayer mario;

        private int starTimer = DataLibrary.STAR_MARIO_TIMER;
        private int timeSinceLastTint = 0;
        private const int millisecondsPerTint = 100;
        private int currentIndex = 0;


        private const int framesPerTint = 4;
        private Color[] tintFrame = {
            Color.Blue,
            Color.Green,
            Color.Yellow,
            Color.Red
        };

        public bool IsInAnimation
        {
            get { return mario.IsInAnimation; }
            set { mario.IsInAnimation = value; }
        }
        public bool RunActivated
        {
            get { return mario.RunActivated; }

            set { mario.RunActivated = value; }
        }
        public bool JumpEnable
        {
            get { return mario.JumpEnable; }

            set { mario.JumpEnable = value; }
        }

        public bool IsMario
        {
            get { return mario.IsMario; }

            set { mario.IsMario = value; }
        }
        public bool IsCrouching { get { return mario.IsCrouching; } }

        public bool CanGoInPipe
        {
            get
            {
                return mario.CanGoInPipe;
            }

            set
            {
                mario.CanGoInPipe = value;
            }
        }

        public bool IsMovingDown
        {
            get { return mario.IsMovingDown; }
            set { mario.IsMovingDown = value; }
        }

        public bool IsMovingRight
        {
            get { return mario.IsMovingRight; }
            set { mario.IsMovingRight = value; }
        }

        public Rectangle DestinationRectangle
        {
            get
            {
                return mario.DestinationRectangle;
            }

            set
            {
                mario.DestinationRectangle = value;
            }
        }

        public bool IsInvincible
        {
            get { return mario.IsInvincible; }
            set { mario.IsInvincible = value; }
        }
        public ISprite CurrentSprite
        {
            get
            {
                return mario.CurrentSprite;
            }

            set
            {
                mario.CurrentSprite = value;
            }
        }

        public Vector2 VelocityVector
        {
            get
            {
                return mario.VelocityVector;
            }
        }

        public Vector2 CurrentLocationVector
        {
            get
            {
                return mario.CurrentLocationVector;
            }

            set
            {
                mario.CurrentLocationVector = value;
            }
        }

        public int Width
        {
            get
            {
                return mario.Width;
            }
        }

        public bool IsIdle
        {
            get
            {
                return mario.IsIdle;
            }
        }

        public bool HitEnemyLast
        {
            get
            {
                return mario.HitEnemyLast;
            }
            set
            {
                mario.HitEnemyLast = value;
            }
        }

        public StarMario(IPlayer mario)
        {
            this.mario = mario;
        }

        public void TakeDamage()
        {
            // No-Op
        }

        public void BeDead()
        {
            // No-Op
        }

        public void Dead()
        {
            // No-Op
        }

        public void BeSmall()
        {
            // No-Op
        }

        public void BeBig()
        {
            mario.BeBig();
        }

        public void BeFire()
        {
            mario.BeFire();
        }

        public void BeIdle()
        {
            // No-Op
        }
        public void UpMovement()
        {
            mario.UpMovement();
        }

        public void DownMovement()
        {
            mario.DownMovement();
        }

        public void LeftMovement()
        {
            mario.LeftMovement();
        }

        public void RightMovement()
        {
            mario.RightMovement();
        }

        public void NormalForce()
        {
            mario.NormalForce();
        }

        public bool IsMarioSmall()
        {
            return mario.IsMarioSmall();
        }
        public bool IsMarioBig()
        {
            return mario.IsMarioBig();
        }
        public bool IsMarioFire()
        {
            return mario.IsMarioFire();
        }
        public bool IsMarioDead()
        {
            return mario.IsMarioDead();
        }

        public bool IsFacingRight()
        {
            return mario.IsFacingRight();
        }
        public void AddLives(int lives)
        {
            mario.AddLives(lives);
        }
        public int GetRemainingLives()
        {
            return mario.GetRemainingLives();
        }

        public void Update(GameTime gameTime)
        {
            starTimer--;
            if (starTimer == 0)
            {
                RemoveStar();
            }

            timeSinceLastTint += gameTime.ElapsedGameTime.Milliseconds;
            if (timeSinceLastTint > millisecondsPerTint)
            {
                timeSinceLastTint -= millisecondsPerTint;
                currentIndex++;
                if (currentIndex == framesPerTint)
                    currentIndex = 0;
            }

            mario.Update(gameTime);
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector)
        {
            Vector2 destRectVector = new Vector2(
                DestinationRectangle.X,
                DestinationRectangle.Y
            );
            Vector2 offsetVector = Vector2.Subtract(destRectVector, cameraOffsetVector);
            Rectangle offsetRectangle = new Rectangle(
                (int)offsetVector.X,
                (int)offsetVector.Y,
                DestinationRectangle.Width,
                DestinationRectangle.Height
            );

            CurrentSprite.Draw(spriteBatch, offsetRectangle, tintFrame[currentIndex]);
        }

        private void RemoveStar()
        {
            MarioGame.Instance.CurrentGameMode.Players[0] = mario; 
            MediaPlayer.Play(SoundFactory.Instance.Music());
        }
    }
}
