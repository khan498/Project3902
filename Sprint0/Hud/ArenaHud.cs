using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.GameMetrics;
using SuperMarioBrothers.HUD;
using SuperMarioBrothers.SpriteFonts;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Hud
{
    public class ArenaHud : IHud
    {
        private GameMetricTracker gameMetricTracker;
        private string worldNumber;

        private SpriteFont font;
        private bool isDoneUpdating;

        public ArenaHud(GameMetricTracker gameMetricTracker, string worldNumber)
        {
            this.gameMetricTracker = gameMetricTracker;

            font = SpriteFontFactory.Instance.GetOriginalHudFont();
            this.worldNumber = worldNumber;
            isDoneUpdating = false;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawPlayerName(spriteBatch);
            DrawTimeLeft(spriteBatch);
            DrawLifeLeft(spriteBatch);
        }

        public void DrawIntermediateScreen(SpriteBatch spriteBatch)
        {
            MarioGame.Instance.GraphicsDevice.Clear(Color.Black);

            DrawPlayerName(spriteBatch);
            DrawTimeLeft(spriteBatch);
            DrawLivesLeft(spriteBatch);
        }

        public void DrawGameOverScreen(SpriteBatch spriteBatch)
        {
            MarioGame.Instance.GraphicsDevice.Clear(Color.Black);

            DrawPlayerName(spriteBatch);
            DrawTimeLeft(spriteBatch);
            if (gameMetricTracker.LifeCounters[0].Value > gameMetricTracker.LifeCounters[1].Value)
            {
                DrawPlayer1Winner(spriteBatch);
            }
            else if (gameMetricTracker.LifeCounters[0].Value < gameMetricTracker.LifeCounters[1].Value)
            {
                DrawPlayer2Winner(spriteBatch);
            }
            else
            {
                DrawGameDraw(spriteBatch);
            }
        }

        public void Update(GameTime gameTime)
        {
            if (!MarioGame.Instance.CurrentGameMode.CurrentLevel.IsEndOfLevel)
            {
                gameMetricTracker.Update(gameTime);
            }
            else
            {
                if (!isDoneUpdating)
                {
                    gameMetricTracker.GameScore.AddValue(gameMetricTracker.GameTimer.Value);
                    isDoneUpdating = true;
                }
            }
        }

        private void DrawPlayerName(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "PLAYER 1", new Vector2(40, 10), Color.White);
            spriteBatch.DrawString(font, "PLAYER 2", new Vector2(650, 10), Color.White);
            spriteBatch.End();
        }

        private void DrawTimeLeft(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, gameMetricTracker.GameTimer.Value.ToString(), new Vector2(385, 30), Color.White);
            spriteBatch.End();
        }

        private void DrawLifeLeft(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "LIFE: " + gameMetricTracker.LifeCounters[0].Value.ToString(), new Vector2(40, 40), Color.White);
            spriteBatch.DrawString(font, "LIFE: " + gameMetricTracker.LifeCounters[1].Value.ToString(), new Vector2(685, 40), Color.White);
            spriteBatch.End();
        }

        private void DrawLivesLeft(SpriteBatch spriteBatch)
        {
            ISprite marioSprite = SpriteFactory.Instance.GetRightIdleSmallMarioSprite();
            ISprite luigiSprite = SpriteFactory.Instance.GetRightIdleSmallLuigiSprite();
            marioSprite.Draw(spriteBatch, new Rectangle(320, 210, 32, 32), Color.White);
            luigiSprite.Draw(spriteBatch, new Rectangle(320, 260, 32, 32), Color.White);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "WORLD " + MarioGame.Instance.CurrentGameMode.CurrentLevel.WorldNumber, new Vector2(300, 170), Color.White);
            spriteBatch.DrawString(font, "x " + gameMetricTracker.LifeCounters[0].Value.ToString(), new Vector2(360, 210), Color.White);
            spriteBatch.DrawString(font, "x " + gameMetricTracker.LifeCounters[1].Value.ToString(), new Vector2(360, 260), Color.White);
            spriteBatch.End();
        }

        private void DrawPlayer1Winner(SpriteBatch spriteBatch)
        {
            ISprite marioSprite = SpriteFactory.Instance.GetRightIdleSmallMarioSprite();
            marioSprite.Draw(spriteBatch, new Rectangle(300, 260, 32, 32), Color.White);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "WINNER", new Vector2(330, 220), Color.White);
            spriteBatch.DrawString(font, "PLAYER 1", new Vector2(340, 265), Color.White);
            spriteBatch.End();
        }

        private void DrawPlayer2Winner(SpriteBatch spriteBatch)
        {
            ISprite luigiSprite = SpriteFactory.Instance.GetRightIdleSmallLuigiSprite();
            luigiSprite.Draw(spriteBatch, new Rectangle(300, 260, 32, 32), Color.White);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "WINNER", new Vector2(330, 220), Color.White);
            spriteBatch.DrawString(font, "PLAYER 2", new Vector2(340, 265), Color.White);
            spriteBatch.End();
        }

        private void DrawGameDraw(SpriteBatch spriteBatch)
        {
            ISprite marioSprite = SpriteFactory.Instance.GetRightIdleSmallMarioSprite();
            ISprite luigiSprite = SpriteFactory.Instance.GetRightIdleSmallLuigiSprite();
            marioSprite.Draw(spriteBatch, new Rectangle(330, 210, 32, 32), Color.White);
            luigiSprite.Draw(spriteBatch, new Rectangle(330, 260, 32, 32), Color.White);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "DRAW ", new Vector2(330, 170), Color.White);
            spriteBatch.DrawString(font, "x " + gameMetricTracker.LifeCounters[0].Value.ToString(), new Vector2(360, 210), Color.White);
            spriteBatch.DrawString(font, "x " + gameMetricTracker.LifeCounters[1].Value.ToString(), new Vector2(360, 260), Color.White);
            spriteBatch.End();
        }
    }
}
