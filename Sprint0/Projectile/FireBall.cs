using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Projectile
{
    public class FireBall : IProjectile
    {
        private const int EXPLOSION_TIMER = 100;
        private int elapsedTime = 0;

        private ISprite sprite;

        private Vector2 location;
        private Vector2 velocity;

        private int pixelWidth;
        private int pixelHeight;

        private bool isActive;
        private bool canBounce;
        private bool isExploding;
        
        public bool IsActive
        {
            get
            {
                return isActive;
            }

            set
            {
                isActive = value;
            }
        }


        public Vector2 Velocity
        {
            get
            {
                return velocity;
            }

            set
            {
                velocity = value;
            }
        }

        public Vector2 Location
        {
            get
            {
                return location;
            }

            set
            {
                location = value;
            }
        }

        public int Width
        {
            get
            {
                return pixelWidth;
            }
        }

        public int Height
        {
            get
            {
                return pixelHeight;
            }
        }

        public bool CanBounce
        {
            get
            {
                return canBounce;
            }

            set
            {
                canBounce = value;
            }
        }

        public FireBall(Vector2 location, Vector2 velocity)
        {
            Initialize(location, velocity);
        }

        public void Update(GameTime gameTime)
        {
            if (isExploding)
            {
                elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
                if (elapsedTime > EXPLOSION_TIMER)
                {
                    isActive = false;
                }
            }
            else
            {
                Move();
                sprite.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector)
        {
            Vector2 destRectVector = new Vector2(
                Location.X,
                Location.Y
            );
            Vector2 offsetVector = Vector2.Subtract(destRectVector, cameraOffsetVector);
            Rectangle offsetRectangle = new Rectangle(
                (int)offsetVector.X,
                (int)offsetVector.Y,
                pixelWidth,
                pixelHeight
            );

            sprite.Draw(spriteBatch, offsetRectangle, Color.White);
        }

        public void Explode()
        {
            if (!isExploding)
            {
                sprite = SpriteFactory.Instance.GetExplodingFireBallSprite();
                pixelWidth += pixelWidth;
                pixelHeight += pixelHeight;
                isExploding = true;
            }
        }

        private void Initialize(Vector2 location, Vector2 velocity)
        {
            this.location = location;
            this.velocity = velocity;

            sprite = SpriteFactory.Instance.GetRollingFireBallSprite();
            pixelWidth = 16;
            pixelHeight = 16;

            isActive = true;
            canBounce = false;
            isExploding = false;
        }

        private void Move()
        {

            if (canBounce)
            {
                velocity = new Vector2(velocity.X, -15);
                canBounce = false;
            }

            location = Vector2.Add(location, velocity);
        }
    }
}
