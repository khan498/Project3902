using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Levels;
using SuperMarioBrothers.Camera;
using SuperMarioBrothers.GameMetrics;
using System.Collections.Generic;

namespace SuperMarioBrothers.GameModes
{
    public interface IGameMode
    {
        List<IPlayer> Players { get; }
        ILevel CurrentLevel { get; set; }
        ICamera Camera { get; }
        GameMetricTracker GameMetric { get; }
        bool GameOverScreen { get; set; }
        bool IsPaused { get; }

        void InitializeGameMode();
        void HardReset();
        void SoftReset();
        void Pause();
        void Unpause();
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch);
    }
}
