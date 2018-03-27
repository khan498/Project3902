using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Physics;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Entities.Enemies
{
    class GreenKoopa : AbstractEnemy
    {
        private WalkingDirection currentDirection;

        private const int width = DataLibrary.DEFAULT_SIZE;
        private const int height = DataLibrary.DEFAULT_SIZE;

        private int timeSinceBecomingShell;
        private const int SHELL_TIMEOUT = 5000;

        private Vector2 currentLocation;
        private ISprite currentSprite;
        
        private bool isStomped = false;
        private bool isLaunched = false;
        private bool isActivated;
        private bool isShell = false;
        public bool movingFast = false;
        public bool stable = true;

        private Rectangle destinationRectangle;
        private EnemyPhysics physics;

        public GreenKoopa(Vector2 currentLocation, int scale = DataLibrary.ENEMY_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetLeftWalkingGreenKoopaSprite();

            destinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, width * scale, height * scale);
            this.currentLocation = currentLocation;
            physics = new EnemyPhysics(this);

            isActivated = false;
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
                return isShell;
            }

            set
            {
                isShell = value;
            }
        }

        public bool MovingFast
        {
            get
            {
                return movingFast;
            }

            set
            {
                movingFast = value;
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
        public override void NormalForce()
        {
            physics.NormalForce();
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
        private void FastShell()
        {
            if (CurrentDirection.Equals(WalkingDirection.LEFT))
            {
                physics.FastLeft();
            }
            else
            {
                physics.FastRight();
            }
            stable = false;
        }

        public override void Update(GameTime gameTime)
        {
            if (!isShell)
            {
                Walk();
                
            }
            else if (movingFast)
            {
                FastShell();
            }
            else
            {
                timeSinceBecomingShell += gameTime.ElapsedGameTime.Milliseconds;
                if (timeSinceBecomingShell > SHELL_TIMEOUT )
                {
                    timeSinceBecomingShell = 0;
                    isShell = false;
                    isStomped = false;
                    CurrentSprite = SpriteFactory.Instance.GetLeftWalkingGreenKoopaSprite();
                    destinationRectangle = new Rectangle(destinationRectangle.X, destinationRectangle.Y, width, height);
                }
            }
            CurrentSprite.Update(gameTime);
            physics.Update(destinationRectangle);
        }

        public override void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector)
        {
            Vector2 destRectVector = new Vector2(DestinationRectangle.X, DestinationRectangle.Y);
            Vector2 offsetVector = Vector2.Subtract(destRectVector, cameraOffsetVector);
            Rectangle offsetRectangle = new Rectangle((int)offsetVector.X, (int)offsetVector.Y - 4, destinationRectangle.Width, destinationRectangle.Height + 4);

            CurrentSprite.Draw(spriteBatch, offsetRectangle, Color.White);
        }

        public override void GetStomped()
        {
            if (!isShell)
            {
                CurrentSprite = SpriteFactory.Instance.GetDeadGreenKoopaSprite();
                isShell = true;
                if (destinationRectangle.Height == height)
                {
                    destinationRectangle.Y += (height / 2 - 4);
                    destinationRectangle.Height -= (height / 2 - 4);
                }
                timeSinceBecomingShell = 0;
                CurrentDirection = WalkingDirection.RIGHT;
                movingFast = true;
            }
            movingFast = !movingFast;
            physics.BeIdle();

        }
        public override void GetLaunched()
        {
            if (!isLaunched)
            {
                physics.LaunchPhysics();
                isLaunched = true;
            }

            if (CurrentDirection.Equals(WalkingDirection.LEFT))
                CurrentSprite = SpriteFactory.Instance.GetFlippedLeftGreenKoopaSprite();
            else
                CurrentSprite = SpriteFactory.Instance.GetFlippedRightGreenKoopaSprite();
        }

        public override void ChangeMovementDirection()
        {
            if (CurrentDirection.Equals(WalkingDirection.LEFT))
            {
                CurrentDirection = WalkingDirection.RIGHT;
                if (!isShell)
                {
                    CurrentSprite = SpriteFactory.Instance.GetRightWalkingGreenKoopaSprite();
                }              
            }
            else
            {
                CurrentDirection = WalkingDirection.LEFT;
                if (!isShell)
                {
                    CurrentSprite = SpriteFactory.Instance.GetLeftWalkingGreenKoopaSprite();
                }
            }
        }
    }
}
