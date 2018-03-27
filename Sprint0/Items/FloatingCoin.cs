using Microsoft.Xna.Framework;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Items
{
    class FloatingCoin : AbstractItem
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;
        private bool isActivated;
        private bool isTransparent;

        private const int width = 20;
        private const int height = DataLibrary.DEFAULT_SIZE;

        public FloatingCoin(Vector2 currentLocation, int scale = DataLibrary.ITEM_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetCoinSprite();
            destinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, width * scale, height * scale);
            isActivated = true;
            isTransparent = false;
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
            // No-Op
        }

        public override void Update(GameTime gameTime)
        {
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
