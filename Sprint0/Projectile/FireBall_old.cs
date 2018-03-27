using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Physics;
using SuperMarioBrothers.Sprites;
using SuperMarioBrothers.Sprites.FireBallSprites;

namespace SuperMarioBrothers.Projectile
{
    public class FireBall_old
    {
        private Rectangle destinationRectangle;
        private ISprite currentSprite;

        private const int width = 16;
        private const int height = 16;

        private bool bounceEnable = false;
        private bool isRevomable = false;
        private bool exploding = false;
        private int elapsedTime = 0;
        private const int explosionTimer = 550;

        private IPlayer mario;
        private Vector2 originCoordinate;
        private FireBallPhysics physics;

        public FireBall_old(IPlayer mario, int scale = 1)
        {
            this.mario = mario;
            physics = new FireBallPhysics(this);

            if (mario.IsFacingRight())
            {
                originCoordinate = new Vector2(mario.DestinationRectangle.Right, (mario.DestinationRectangle.Top + mario.DestinationRectangle.Bottom) / 2);
                physics.MoveRight();
            }
            else
            {
                originCoordinate = new Vector2(mario.DestinationRectangle.Left, (mario.DestinationRectangle.Top + mario.DestinationRectangle.Bottom) / 2);
                physics.MoveLeft();
            }

            CurrentSprite = SpriteFactory.Instance.GetRollingFireBallSprite();
            DestinationRectangle = new Rectangle((int)originCoordinate.X, (int)originCoordinate.Y, width * scale, height * scale);
        }

        public bool BounceEnable
        {
            get { return bounceEnable; }
            set { bounceEnable = value; }
        }

        public bool IsRemovable
        {
            get { return isRevomable; }
        }

        public bool Exploding
        {
            get { return exploding; }
        }

        public ISprite CurrentSprite
        {
            get { return currentSprite; }
            set { currentSprite = value; }
        }

        public Rectangle DestinationRectangle
        {
            get { return destinationRectangle; }
            set { destinationRectangle = value; }
        }

        public void Bounce()
        {
            if (BounceEnable)
            {
                physics.Bounce();
            }
        }
        
        public void Update(GameTime gameTime)
        {
            physics.Update(destinationRectangle);
            CurrentSprite.Update(gameTime);

            if (BounceEnable)
            {
                Bounce();
            }

            if (currentSprite is ExplodingFireBallSprite)
            {
                elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
                if (elapsedTime > explosionTimer)
                {
                    isRevomable = true;
                }
            }
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

            CurrentSprite.Draw(spriteBatch, offsetRectangle, Color.White);
        }

        public void Explode()
        {
            destinationRectangle = new Rectangle(destinationRectangle.X - 8, destinationRectangle.Y - 8, destinationRectangle.Width + 8, destinationRectangle.Height + 8);
            currentSprite = SpriteFactory.Instance.GetExplodingFireBallSprite();
            exploding = true;
        }

        public void NormalForce()
        {
            physics.NormalForce();
        }
    }
}
