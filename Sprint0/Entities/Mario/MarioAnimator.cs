using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Entities.Mario
{
    class MarioAnimator
    {
        private const int DEATH_TIME_LIMIT = 2700;
        private int deathTimer;

        private const int BLINK_TIME_LIMIT = 200;
        private int blinkTimer;

        private IPlayer mario;
        private bool blinking;

        public MarioAnimator(IPlayer mario)
        {
            this.mario = mario;
            blinking = false;
        }

        public void AnimateDeath(GameTime gameTime)
        {
            deathTimer += gameTime.ElapsedGameTime.Milliseconds;
            mario.DestinationRectangle = new Rectangle(mario.DestinationRectangle.X, mario.DestinationRectangle.Y + 3,
                mario.DestinationRectangle.Width, mario.DestinationRectangle.Height);

            if (deathTimer > DEATH_TIME_LIMIT)
            {
                if (mario.GetRemainingLives() > 0)    //mario.getLife
                {
                    MarioGame.Instance.SoftResetGame();
                }
                else if (mario.GetRemainingLives() == 0)
                {
                    MarioGame.Instance.CurrentGameMode.GameOverScreen = true;
                }
            }
        }

        public void AnimateInvinsibilityBlink(GameTime gameTime, bool isInvinsible)
        {
            blinkTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (isInvinsible && blinkTimer > BLINK_TIME_LIMIT)
            {
                blinkTimer -= BLINK_TIME_LIMIT;
                blinking = !blinking;
            }
            else
            {
                blinking = false;
            }
        }

        public void DrawAjdustedMario(SpriteBatch spriteBatch, Vector2 cameraOffsetVector)
        {
            Vector2 destRectVector = new Vector2(
                mario.DestinationRectangle.X,
                mario.DestinationRectangle.Y
            );

            Vector2 offsetVector = Vector2.Subtract(destRectVector, cameraOffsetVector);
            Rectangle offsetRectangle = new Rectangle(
                (int)offsetVector.X,
                (int)offsetVector.Y,
                mario.DestinationRectangle.Width,
                mario.DestinationRectangle.Height
            );

            if (blinking)
            {
                mario.CurrentSprite.Draw(spriteBatch, offsetRectangle, Color.Transparent);
            }
            else
            {
                mario.CurrentSprite.Draw(spriteBatch, offsetRectangle, Color.White);
            }
        }
    }
}
