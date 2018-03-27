using Microsoft.Xna.Framework;
using SuperMarioBrothers.Sprites;
using SuperMarioBrothers.Physics;
using SuperMarioBrothers.Level_Files;

namespace SuperMarioBrothers.Items
{
    class BigMushroom : AbstractItem
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;
        private bool isActivated;
        private MovementDirection currentDirection = MovementDirection.RIGHT;
        private bool risingUp = false;
        private bool isTransparent;

        private const int width = DataLibrary.DEFAULT_SIZE;
        private const int height = DataLibrary.DEFAULT_SIZE;
        private int maxHeight;
        private BigMushroomPhysics physics;

        public BigMushroom(Vector2 currentLocation, int scale = DataLibrary.ITEM_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetBigMushroomSprite();
            destinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, width * scale, height * scale);
            isActivated = false;
            isTransparent = true;

            maxHeight = (int)currentLocation.Y - height * scale;
            physics = new BigMushroomPhysics(this);
        }

        public override ISprite CurrentSprite
        {
            get { return currentSprite; }

            set { currentSprite = value; }
        }

        public override Rectangle DestinationRectangle
        {
            get { return destinationRectangle; }

            set { destinationRectangle = value; }
        }

        public override bool IsActivated
        {
            get { return isActivated; }

            set { isActivated = value; }
        }

        public override bool IsTransparent
        {
            get { return isTransparent; }
            set { isTransparent = value; }
        }

        public override void ChangeMovementDirection()
        {
            if (currentDirection == MovementDirection.RIGHT)
                currentDirection = MovementDirection.LEFT;
            else
                currentDirection = MovementDirection.RIGHT;
        }

        public override void RiseUp()
        {
            risingUp = true;
        }

        public override void Update(GameTime gameTime)
        {
            if (risingUp && destinationRectangle.Y > maxHeight)
            {
                destinationRectangle.Y -= 2;
            }
            else if (destinationRectangle.Y <= maxHeight)
            {
                risingUp = false;
                IsActivated = true;
                physics.g = true;
            }

            if (IsActivated)
            {
                Move();
            }

            physics.Update(destinationRectangle);
            CurrentSprite.Update(gameTime);
        }

        public override void Move()
        {
            if (currentDirection == MovementDirection.RIGHT)
            {
                physics.MoveRight();
            }
            else
            {
                physics.MoveLeft();
            }
        }

        public override void NormalForce()
        {
            physics.NormalForce();
        }

        public override void BounceUp()
        {

        }

    }
}
