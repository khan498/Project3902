using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.GameMetrics;
using SuperMarioBrothers.HUD;
using SuperMarioBrothers.SpriteFonts;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Hud
{
    public class ClassicHud : IHud
    {
        private GameMetricTracker gameMetricTracker;
        private string worldNumber;
        private ISprite coinCounterSprite;

        private SpriteFont font;
        private bool isDoneUpdating;

        public ClassicHud(GameMetricTracker gameMetricTracker, string worldNumber)
        {
            this.gameMetricTracker = gameMetricTracker;

            font = SpriteFontFactory.Instance.GetOriginalHudFont();
            this.worldNumber = worldNumber;
            isDoneUpdating = false;
            coinCounterSprite = SpriteFactory.Instance.GetCoinCounterSprite();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            DrawPlayerName(spriteBatch);
            DrawTimeLeft(spriteBatch);
            DrawLevelName(spriteBatch);
            DrawLifeLeft(spriteBatch);
            DrawScore(spriteBatch);
            DrawCoins(spriteBatch);
        }

        public void DrawIntermediateScreen(SpriteBatch spriteBatch)
        {
            MarioGame.Instance.GraphicsDevice.Clear(Color.Black);

            DrawPlayerName(spriteBatch);
            DrawScore(spriteBatch);
            DrawCoins(spriteBatch);
            DrawLevelName(spriteBatch);
            DrawTimeLeft(spriteBatch);
            DrawLivesLeft(spriteBatch);
        }

        public void DrawGameOverScreen(SpriteBatch spriteBatch)
        {
            MarioGame.Instance.GraphicsDevice.Clear(Color.Black);

            DrawPlayerName(spriteBatch);
            DrawScore(spriteBatch);
            DrawCoins(spriteBatch);
            DrawLevelName(spriteBatch);
            DrawTimeLeft(spriteBatch);
            DrawGameOver(spriteBatch);
        }

        public void Update(GameTime gameTime)
        {
            if (!MarioGame.Instance.CurrentGameMode.CurrentLevel.IsEndOfLevel)
            {
                gameMetricTracker.Update(gameTime);
                coinCounterSprite.Update(gameTime);
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
            spriteBatch.DrawString(font, "MARIO", new Vector2(20, 20), Color.White);
            spriteBatch.End();
        }

        private void DrawTimeLeft(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "TIME", new Vector2(725, 20), Color.White);
            spriteBatch.DrawString(font, gameMetricTracker.GameTimer.Value.ToString(), new Vector2(725, 40), Color.White);
            spriteBatch.End();
        }

        private void DrawLevelName(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "WORLD", new Vector2(500, 20), Color.White);
            spriteBatch.DrawString(font, worldNumber, new Vector2(500, 40), Color.White);
            spriteBatch.End();
        }
        
        private void DrawLifeLeft(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "LIFE", new Vector2(250, 20), Color.White);
            spriteBatch.DrawString(font, gameMetricTracker.LifeCounters[0].Value.ToString(), new Vector2(250, 40), Color.White);
            spriteBatch.End();
        }
        private void DrawScore(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, gameMetricTracker.GameScore.Value.ToString(), new Vector2(20, 40), Color.White);
            spriteBatch.End();
        }

        private void DrawCoins(SpriteBatch spriteBatch)
        {
            Rectangle destinationRectangle = new Rectangle(350, 40, 15, 24);
            coinCounterSprite.Draw(spriteBatch, destinationRectangle, Color.White);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "x" + gameMetricTracker.CoinCounter.Value.ToString(), new Vector2(370, 40), Color.White);
            spriteBatch.End();
        }

        private void DrawLivesLeft(SpriteBatch spriteBatch)
        {
            ISprite marioSprite = SpriteFactory.Instance.GetRightIdleSmallMarioSprite();
            marioSprite.Draw(spriteBatch, new Rectangle(320, 210, 32, 32), Color.White);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "WORLD " + MarioGame.Instance.CurrentGameMode.CurrentLevel.WorldNumber, new Vector2(300, 170), Color.White);
            spriteBatch.DrawString(font, "x " + gameMetricTracker.LifeCounters[0].Value.ToString(), new Vector2(360, 210), Color.White);
            spriteBatch.End();
        }

        private void DrawGameOver(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "GAME OVER", new Vector2(325, 250), Color.White);
            spriteBatch.End();
        }
    }
}
