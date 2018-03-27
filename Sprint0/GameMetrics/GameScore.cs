using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.SpriteFonts;
using System.Collections.Generic;

namespace SuperMarioBrothers.GameMetrics
{
    public class GameScore : IGameMetric
    {
        private int score = 0;
        private int powerUpScore = 1000;
        private int coinScore = 200;
        private int blockScore = 50;
        private int scoreTimeOut = 1000;
        private int displayTime = 0;
        private int yOffset = 10;
        private int[] flagScores = new int []{ 5000, 2000, 800, 400, 100 };
        private int[] chainKillScores = new int[] { 100, 200 ,400, 500 ,800 , 1000 ,2000 , 4000 , 5000, 8000 };
        private int chainKillIndex = 0;
        private int[] shellKillScores = new int[] {500, 800, 1000, 2000, 4000, 5000, 8000 };
        private int shellKillIndex = 0;

        private SpriteFont font;
        private List<ScoreInfo> scoresOnScreen;

        public int Value
        {
            get
            {
                return score;
            }
        }
        public GameScore()
        {
            score = 0;
            scoresOnScreen = new List<ScoreInfo>();
            font = SpriteFontFactory.Instance.GetOriginalHudFont();
        }
        public void Update(GameTime gameTime)
        {
            displayTime += gameTime.ElapsedGameTime.Milliseconds;
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 cameraOffsetVector)
        {

            foreach (ScoreInfo s in scoresOnScreen.ToArray())
            {
                if((displayTime - s.timeValue) > scoreTimeOut)
                {
                    scoresOnScreen.Remove(s);
                }
                else
                {
                    DrawScore(spriteBatch, s, cameraOffsetVector);
                }              
            }
        }

        public void PowerUpScore(int x, int y)
        {
            score += powerUpScore;
            scoresOnScreen.Add(new ScoreInfo(x, y, powerUpScore, displayTime));
        }
        public void CoinScore(int x, int y)
        {
            score += coinScore;
            scoresOnScreen.Add(new ScoreInfo(x, y, coinScore, displayTime));
        }
        public void BlockScore(int x, int y)
        {
            score += blockScore;
            scoresOnScreen.Add(new ScoreInfo(x, y, blockScore, displayTime));
        }
        public void EnemyStompScore(int x, int y, bool chainKill)
        {
            if(chainKill && chainKillIndex < chainKillScores.Length)
            {
                chainKillIndex++;
            }
            else
            {
                chainKillIndex = 0;
            }
            score += chainKillScores[chainKillIndex];
            scoresOnScreen.Add(new ScoreInfo(x, y, chainKillScores[chainKillIndex], displayTime));
        }
        public void EnemyLaunchScore(int x, int y, bool shellKill)
        {
            if (shellKill && shellKillIndex < shellKillScores.Length)
            {
                shellKillIndex++;
            }
            else
            {
                shellKillIndex = 0;
            }
            score += shellKillScores[shellKillIndex];
            scoresOnScreen.Add(new ScoreInfo(x, y, shellKillScores[shellKillIndex], displayTime));
        }

        public void FlagScore(int x, int y, int position)
        {
            score += flagScores[position];
            scoresOnScreen.Add(new ScoreInfo(x, y, flagScores[position], displayTime));
        }

        public void AddValue(int value)
        {
            score += value;
        }

        private void DrawScore(SpriteBatch spriteBatch, ScoreInfo score, Vector2 cameraOffsetVector)
        {
            Vector2 destRectVector = new Vector2(
            score.x,
            score.y - yOffset
            );
            Vector2 offsetVector = Vector2.Subtract(destRectVector, cameraOffsetVector);
            spriteBatch.Begin();
            spriteBatch.DrawString(font, score.value.ToString() , offsetVector, Color.White,0,new Vector2(0,0),(float)0.75,0,0);
            spriteBatch.End();
        }
    }
}
