using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace SuperMarioBrothers.GameMetrics
{
    public class GameMetricTracker
    {
        private GameScore gameScore;
        private CoinCounter coinCounter;
        private List<LifeCounter> lifeCounters;
        private LevelTimer gameTimer;
        private int timeLimit;
        private int startingLives;
        private bool isMultiplayer;

        public GameScore GameScore
        {
            get { return gameScore; }
        }

        public IGameMetric CoinCounter
        {
            get { return coinCounter; }
        }

        public List<LifeCounter> LifeCounters
        {
            get { return lifeCounters; }
        }

        public IGameMetric GameTimer
        {
            get { return gameTimer; }
        }

        public GameMetricTracker (int startingLives, int timeLimit, bool isMultiplayer)
        {
            this.isMultiplayer = isMultiplayer;
            this.timeLimit = timeLimit;
            this.startingLives = startingLives;
            Initialize();
        }

        public void Update(GameTime gameTime)
        {
            gameScore.Update(gameTime);
            gameTimer.Update(gameTime);
            coinCounter.Update(gameTime);
        }

        public void PartialReset()
        {
            gameScore = new GameScore();
            coinCounter = new CoinCounter();
        }

        public void TimerReset()
        {
            gameTimer = new LevelTimer(timeLimit);
        }

        private void Initialize()
        {
            PartialReset();
            TimerReset();
            lifeCounters = new List<LifeCounter>
            {
                new LifeCounter(startingLives)
            };

            if (isMultiplayer)
            {
                lifeCounters.Add(new LifeCounter(startingLives));
            }
        }
    }
}
