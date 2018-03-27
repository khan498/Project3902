using Microsoft.Xna.Framework;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Items
{
    class FireFlower : AbstractItem
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;
        private bool isActivated;
        private bool risingUp = false;
        private bool isTransparent;

        private const int width = DataLibrary.DEFAULT_SIZE;
        private const int height = DataLibrary.DEFAULT_SIZE;
        private int maxHeight;

        public FireFlower(Vector2 currentLocation, int scale = DataLibrary.ITEM_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetFireFlowerSprite();
            destinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, width * scale, height * scale);
            isActivated = false;
            isTransparent = true;

            maxHeight = (int)currentLocation.Y - height * scale;
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
            // No-Op
        }

        public override void Move()
        {
            // No-Op
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
            }

            CurrentSprite.Update(gameTime);
        }

        public override void NormalForce()
        {
        }

        public override void BounceUp()
        {

        }
    }
}
