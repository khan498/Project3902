using Microsoft.Xna.Framework;

namespace SuperMarioBrothers.GameMetrics
{
    public class CoinCounter : IGameMetric
    {
        private int numCoins;

        public int Value
        {
            get
            {
                return numCoins;
            }
        }

        public CoinCounter()
        {
            Initialize();
        }

        public void Update(GameTime gameTime)
        {
            // No-op
        }

        public void AddValue(int value)
        {
            numCoins += value;
        }

        private void Initialize()
        {
            numCoins = 0;
        }
    }
}
