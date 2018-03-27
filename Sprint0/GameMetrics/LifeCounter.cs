using Microsoft.Xna.Framework;
using SuperMarioBrothers;
using SuperMarioBrothers.Entities.Mario;

namespace SuperMarioBrothers.GameMetrics
{
    public class LifeCounter : IGameMetric
    {
        private int livesLeft;

        public int Value { get { return livesLeft; } }

        public LifeCounter(int lives)
        {
            Initialize(lives);
        }

        public void Update(GameTime gameTime)
        {
            // No-op
        }

        public void AddValue(int value)
        {
            livesLeft += value;
        }

        private void Initialize(int lives)
        {
            livesLeft = lives;
        }
    }
}
