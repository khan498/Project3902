using Microsoft.Xna.Framework;
using System;
using SuperMarioBrothers.Sounds;
using Microsoft.Xna.Framework.Media;
using SuperMarioBrothers.GameModes;

namespace SuperMarioBrothers.GameMetrics
{
    public class LevelTimer : IGameMetric
    {
        private int timeLeftSeconds = 0;
        private TimeSpan elapsedTime;

        public int Value { get { return timeLeftSeconds; } }

        public LevelTimer(int timeLeftSeconds)
        {
            Initialize(timeLeftSeconds);
        }

        public void Update(GameTime gameTime)
        {
            if (timeLeftSeconds > 0)
            {
                elapsedTime += gameTime.ElapsedGameTime;

                if (elapsedTime.Seconds >= 1)
                {
                    elapsedTime = new TimeSpan(0, 0, 0);
                    AddValue(-1);
                }

                PlaySounds();
            }
        }

        public void AddValue(int value)
        {
            timeLeftSeconds += value;
        }

        private void Initialize(int timeLeftSeconds)
        {
            this.timeLeftSeconds = timeLeftSeconds;
        }

        private void PlaySounds()
        {
            if (timeLeftSeconds == 100 && MarioGame.Instance.CurrentGameMode is ClassicGameMode)
            {
                MediaPlayer.Play(SoundFactory.Instance.Hurrygame());
            }
            else if (timeLeftSeconds == 0)
            {
                MarioGame.Instance.CurrentGameMode.GameOverScreen = true;
            }
        }
    }
}
