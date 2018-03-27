using Microsoft.Xna.Framework;

namespace SuperMarioBrothers
{
    public interface IGameMetric
    {
        int Value { get; }

        void Update(GameTime gameTime);

        void AddValue(int value);
    }
}
