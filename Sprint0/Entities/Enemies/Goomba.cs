using Microsoft.Xna.Framework;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Physics;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Entities.Enemies
{
    class Goomba : AbstractEnemy
    {
        private const int width = DataLibrary.DEFAULT_SIZE;
        private const int height = DataLibrary.DEFAULT_SIZE;

        private const int GOOMBA_DEATH_TIMELIMIT = 650;
        
        private WalkingDirection currentDirection;
        private Vector2 currentLocation;

        private Rectangle destinationRectangle;

        private ISprite currentSprite;

        private bool isStomped;
        private bool isLaunched = false;
        private bool isActivated;
        private int deadTime;

        private Vector2 leftVelocityVector;
        private Vector2 rightVelocityVector;
        private EnemyPhysics physics;

        public Goomba(Vector2 currentLocation, int scale = DataLibrary.ENEMY_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetWalkingGoombaSprite();
            this.currentLocation = currentLocation;
            currentDirection = WalkingDirection.LEFT;

            destinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, width * scale, height * scale);
            leftVelocityVector = new Vector2(-0.5f, 0.0f);
            rightVelocityVector = new Vector2(0.5f, 0.0f);
            physics = new EnemyPhysics(this);

            isActivated = false;
        }

        public override Rectangle DestinationRectangle
        {
            get
            {
                return destinationRectangle;
            }

            set
            {
                destinationRectangle = value;
            }
        }

        public WalkingDirection CurrentDirection
        {
            get
            {
                return currentDirection;
            }

            set
            {
                currentDirection = value;
            }
        }

        public override ISprite CurrentSprite
        {
            get
            {
                return currentSprite;
            }

            set
            {
                currentSprite = value;
            }
        }

        public override Vector2 CurrentLocation
        {
            get
            {
                return currentLocation;
            }

            set
            {
                currentLocation = value;
            }
        }

        public override bool IsStomped
        {
            get
            {
                return isStomped;
            }

            set
            {
                isStomped = value;
            }
        }
        public override bool IsLaunched
        {
            get
            {
                return isLaunched;
            }

            set
            {
                isLaunched = value;
            }
        }

        public override bool IsActivated
        {
            get
            {
                return isActivated;
            }

            set
            {
                isActivated = value;
            }
        }
        public override bool IsShell
        {
            get
            {
                return false;
            }

            set
            {
            }
        }

        public override void NormalForce()
        {
            physics.NormalForce();
        }

        public override void Update(GameTime gameTime)
        {
            if (!isStomped && IsActivated)
            {
                Walk();
            }
            else
            {
                deadTime += gameTime.ElapsedGameTime.Milliseconds;
                if(deadTime > GOOMBA_DEATH_TIMELIMIT)
                {
                    destinationRectangle.Y = 1000;
                }
            }
            CurrentSprite.Update(gameTime);
            physics.Update(destinationRectangle);
        }

        private void Walk()
        {
            if (CurrentDirection == WalkingDirection.LEFT)
            {
                physics.MoveLeft();
            }
            else if (CurrentDirection == WalkingDirection.RIGHT)
            {
                physics.MoveRight();
            }
        }

        public override void GetStomped()
        {
            isStomped = true;
            CurrentSprite = SpriteFactory.Instance.GetDeadGoombaSprite();
            physics.BeIdle();

            if (destinationRectangle.Height == height)
            {
                destinationRectangle.Y += height / 2;
                destinationRectangle.Height -= height / 2;
            }
        }

        public override void GetLaunched()
        {
            if (!isLaunched)
            {
                physics.LaunchPhysics();
                isLaunched = true;
            }

            CurrentSprite = SpriteFactory.Instance.GetFlippedGoombaSprite();
        }

        public override void ChangeMovementDirection()
        {
            if (CurrentDirection.Equals(WalkingDirection.LEFT))
            {
                CurrentDirection = WalkingDirection.RIGHT;
            }
            else
            {
                CurrentDirection = WalkingDirection.LEFT;
            }
        }
    }
}
