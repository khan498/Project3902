using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.EnvironmentObjects
{
    class Castle : AbstractEnvironmentObject
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;
        private bool ignoreCollision;

        private const int width = 160;
        private const int height = 160;

        public Castle(Vector2 currentLocation, int scale = DataLibrary.CASTLE_SCALE)
        {
            currentSprite = SpriteFactory.Instance.GetCastleSprite();
            destinationRectangle = new Rectangle((int)currentLocation.X, (int)currentLocation.Y, width * scale, height * scale);
            ignoreCollision = true;
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

        public override bool IgnoreCollision
        {
            get { return ignoreCollision; }
            set { ignoreCollision = value; }
        }

        public override void Update(GameTime gameTime)
        {
            CurrentSprite.Update(gameTime);
        }
    }
}
