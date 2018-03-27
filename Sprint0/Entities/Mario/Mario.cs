using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Sprites;
using SuperMarioBrothers.Physics;
using static SuperMarioBrothers.Entities.Mario.MarioStateMachine;
using SuperMarioBrothers.Level_Files;

namespace SuperMarioBrothers.Entities.Mario
{
    public class Mario : IPlayer
    {
        private const int width = DataLibrary.DEFAULT_SIZE;
        private const int height = DataLibrary.DEFAULT_SIZE;
        private const int moveSpeed = DataLibrary.PLAYER_MOVEMENT_SPEED;
        private bool moving;
        private bool jumpEnable;
        private bool runActivated = false;
        private bool isInAnimation = false;
        private bool hitEnemyLast = false;
        private bool canGoInPipe = false;

        private bool isMovingDown;
        private bool isMovingRight;

        private bool isMario;

        private bool isInvincible;

        private Rectangle destinationRectangle;
        private ISprite currentSprite;

        private MarioStateMachine marioStateMachine;
        private MarioPhysics physics;
        private MarioAnimator marioAnimator;

        public bool RunActivated
        {
            get { return runActivated; }
            set { runActivated = value; }
        }
        public bool JumpEnable
        {
            get { return jumpEnable; }
            set { jumpEnable = value; }
        }

        public Rectangle DestinationRectangle
        {
            get { return destinationRectangle; }
            set { destinationRectangle = value; }
        }

        public bool IsInAnimation
        {
            get { return isInAnimation; }
            set { isInAnimation = value; }
        }

        public bool IsCrouching
        {
            get { return marioStateMachine.CurrentMovement.Equals(MarioMovement.Crouching); }
        }

        public bool IsMario
        {
            get { return isMario; }
            set { isMario = value; }
        }

        public bool IsInvincible
        {
            get { return isInvincible; }
            set { isInvincible = value; }
        }

        public bool CanGoInPipe
        {
            get { return canGoInPipe; }
            set { canGoInPipe = value; }
        }

        public bool IsMovingDown
        {
            get { return isMovingDown; }
            set { isMovingDown = value; }
        }

        public bool IsMovingRight
        {
            get { return isMovingRight; }
            set { isMovingRight = value; }
        }

        public bool IsTryingToCrouch
        {
            get { return IsTryingToCrouch; }
        }

        public ISprite CurrentSprite
        {
            get { return currentSprite; }
            set { currentSprite = value; }
        }

        public Vector2 VelocityVector
        {
            get { return physics.Velocity; }
        }

        public Vector2 CurrentLocationVector
        {
            get { return new Vector2(DestinationRectangle.X, DestinationRectangle.Y); }
            set { DestinationRectangle = new Rectangle((int)value.X, (int)value.Y, DestinationRectangle.Width, DestinationRectangle.Height); }
        }

        public int Width
        {
            get { return DestinationRectangle.Width; }
        }

        public bool IsIdle
        {
            get { return marioStateMachine.IsIdle; }
        }

        public bool HitEnemyLast
        {
            get { return hitEnemyLast; }
            set { hitEnemyLast = value; }
        }

        public Mario(Vector2 location, bool ismario, int scale = DataLibrary.PLAYER_SCALE)
        {
            if(ismario)
                CurrentSprite = SpriteFactory.Instance.GetRightIdleSmallMarioSprite();
            else
                CurrentSprite = SpriteFactory.Instance.GetRightIdleSmallLuigiSprite();
            marioStateMachine = new MarioStateMachine(this, ismario);
            destinationRectangle = new Rectangle((int)location.X, (int)location.Y, width * scale, height * scale);
            moving = false;
            physics = new MarioPhysics(this);
            marioAnimator = new MarioAnimator(this);
            this.isMario = ismario;
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector)
        {
            marioAnimator.DrawAjdustedMario(spriteBatch, cameraOffsetVector);
        }

        public void Update(GameTime gameTime)
        {
            marioStateMachine.Update(gameTime);
            CurrentSprite.Update(gameTime);
            marioAnimator.AnimateInvinsibilityBlink(gameTime, marioStateMachine.IsInvincible);

            if (!IsMarioDead() && !isInAnimation)
            {
                physics.Update(destinationRectangle);
            }
            if ((!moving) && (!IsMarioDead()))
            {
                BeIdle();
            }
            if (IsMarioDead())
            {
                marioAnimator.AnimateDeath(gameTime);
            }
            isInvincible = marioStateMachine.IsInvincible;
            moving = false;
        }

        public void TakeDamage()
        {
            marioStateMachine.TakeDamage();
        }

        public void BeDead()
        {
            marioStateMachine.BeDead();
        }
        public void Dead()
        {
            destinationRectangle.Y -= 30;
        }

        public void BeSmall()
        {
            marioStateMachine.BeSmall();
        }
        public void BeBig()
        {
            marioStateMachine.BeBig();
        }
        public void BeFire()
        {
            marioStateMachine.BeFire();
        }
        public void BeIdle()
        {
            marioStateMachine.BeIdle();
            physics.BeIdle();
            runActivated = false;
        }

        public void UpMovement()
        {
            marioStateMachine.UpMovement();
            physics.Jump();
            moving = true;
        }

        public void DownMovement()
        {
            marioStateMachine.DownMovement();
            moving = true;
        }

        public void LeftMovement()
        {
            marioStateMachine.LeftMovement();
            if (!runActivated)
            {
                physics.MoveLeft();
                moving = true;
            }
            else
            {
                physics.RunLeft();
                moving = true;
            } 
        }

        public void RightMovement()
        {
            marioStateMachine.RightMovement();
            if (!runActivated)
            {
                physics.MoveRight();
                moving = true;
            }
            else
            {
                physics.RunRight();
                moving = true;
            }
        }

        public void NormalForce()
        {
            physics.NormalForce();
        }

        public bool IsMarioSmall()
        {
            return marioStateMachine.CurrentState == MarioStatus.Small;
        }
        public bool IsMarioBig()
        {
            return marioStateMachine.CurrentState == MarioStatus.Big;
        }
        public bool IsMarioFire()
        {
            return marioStateMachine.CurrentState == MarioStatus.Fire;
        }
        public bool IsMarioDead()
        {
            return marioStateMachine.CurrentState == MarioStatus.Dead;
        }

        public bool IsFacingRight()
        {
            return marioStateMachine.FacingRight;
        }

        public void AddLives(int lives)
        {
            if (isMario)
                MarioGame.Instance.CurrentGameMode.GameMetric.LifeCounters[0].AddValue(lives);
            else
                MarioGame.Instance.CurrentGameMode.GameMetric.LifeCounters[1].AddValue(lives);
        }
        public int GetRemainingLives()
        {
            if (isMario)
                return MarioGame.Instance.CurrentGameMode.GameMetric.LifeCounters[0].Value;
            else
                return MarioGame.Instance.CurrentGameMode.GameMetric.LifeCounters[1].Value;
        }
    }
}
