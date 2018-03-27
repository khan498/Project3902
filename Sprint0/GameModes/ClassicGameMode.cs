using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Controllers;
using SuperMarioBrothers.Entities.Mario;
using System.Collections.Generic;
using SuperMarioBrothers.Levels;
using SuperMarioBrothers.Camera;
using SuperMarioBrothers.HUD;
using SuperMarioBrothers.Hud;
using SuperMarioBrothers.GameMetrics;
using SuperMarioBrothers.Sounds;
using Microsoft.Xna.Framework.Media;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Commands.MarioCommands;

namespace SuperMarioBrothers.GameModes
{
    public class ClassicGameMode : IGameMode
    {
        private const int STARTING_LIVES = DataLibrary.DEFAULT_LIVES;
        private const int GAMEOVER_RESET_TIMER = 5000;
        private const int LEVELEND_RESET_TIMER = 7500;
        private const int INTERMEDIATE_SCREEN_TIMER = 3000;
        private int elapsedTime;
        private int endGameTimer;

        private static Vector2 playerStartLocation = new Vector2(32, 384);
        private static Vector2 cameraStartLocation = new Vector2(0, 0);

        private Game currentGame;
        private List<IPlayer> players;

        private List<ILevel> levels;
        private ILevel currentLevel;
        private bool isPaused = false;

        private IController keyboard;
        private IController gamepad;
        private ICameraController cameraController;

        private ICamera camera;
        private IHud hud;
        private GameMetricTracker gameMetricTracker;

        private bool showIntermediateScreen;
        private bool showGameOverScreen;
        private bool startEndOfLevelMusic;
        private bool startGameOverMusic;

        public List<IPlayer> Players
        {
            get { return players; }
            set { players = value; }
        }

        public ILevel CurrentLevel
        {
            get { return currentLevel; }
            set { currentLevel = value; }
        }

        public bool GameOverScreen
        {
            get { return showGameOverScreen; }
            set { showGameOverScreen = value; }
        }

        public ICamera Camera
        {
            get { return camera; }
        }

        public GameMetricTracker GameMetric
        {
            get { return gameMetricTracker; } 
        }

        public bool IsPaused
        {
            get { return isPaused; }
        }

        public ClassicGameMode(Game game)
        {
            currentGame = game;
        }

        public void InitializeGameMode()
        {
            InitializePlayer();
            InitializeLevels();
            gameMetricTracker = new GameMetricTracker(STARTING_LIVES, currentLevel.TimeLimitSeconds, false);

            keyboard = new ClassicKeyboardController(players[0]);
            gamepad = new GamepadController(players[0]);

            hud = new ClassicHud(gameMetricTracker, CurrentLevel.WorldNumber);

            MediaPlayer.Play(SoundFactory.Instance.Music());
            InitializeCamera();
            showGameOverScreen = false;
        }

        public void HardReset()
        {
            InitializeGameMode();
            MediaPlayer.Play(SoundFactory.Instance.Music());
            elapsedTime = 0;
        }
        public void SoftReset()
        {
            InitializePlayer();
            InitializeLevels();
            gameMetricTracker.PartialReset();
            gameMetricTracker.TimerReset();

            keyboard = new ClassicKeyboardController(players[0]);
            gamepad = new GamepadController(players[0]);
            InitializeCamera();
            MediaPlayer.Play(SoundFactory.Instance.Music());

            hud = new ClassicHud(gameMetricTracker, CurrentLevel.WorldNumber);
            elapsedTime = 0;
        }
        public void Pause()
        {
            if (!showIntermediateScreen && !showGameOverScreen)
            {
                MediaPlayer.Pause();
                isPaused = true;
            }
        }

        public void Unpause()
        {
            isPaused = false;
        }

        public void Update(GameTime gameTime)
        {
            elapsedTime += gameTime.ElapsedGameTime.Milliseconds;
            if (elapsedTime < INTERMEDIATE_SCREEN_TIMER)
            {
                MediaPlayer.Pause();
                showIntermediateScreen = true;
            }
            else
            {
                showIntermediateScreen = false;
            }

            keyboard.Update(gameTime);
            gamepad.Update(gameTime);

            if (!IsPaused && !showIntermediateScreen && !showGameOverScreen)
            {
                if (!CurrentLevel.IsEndOfLevel)
                {
                    MediaPlayer.Resume();
                }
                players[0].Update(gameTime);
                CurrentLevel.Update(gameTime);
                cameraController.Update();
                hud.Update(gameTime);
            }

            if (currentLevel.IsEndOfLevel)
            {
                EndLevel(gameTime);
            }
            if (showGameOverScreen)
            {
                GameOver(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!showIntermediateScreen && !showGameOverScreen)
            {
                currentGame.GraphicsDevice.Clear(Color.CornflowerBlue);

                camera.Draw(spriteBatch);
                players[0].Draw(spriteBatch, camera.OffsetVector);
                hud.Draw(spriteBatch);
            }
            else if (showIntermediateScreen)
            {
                hud.DrawIntermediateScreen(spriteBatch);
            }
            else if (showGameOverScreen)
            {
                hud.DrawGameOverScreen(spriteBatch);
            }
        }

        private void InitializePlayer()
        {
            players = new List<IPlayer>
            {
                new Mario(playerStartLocation, true)
            };
        }

        private void InitializeLevels()
        {
            levels = new List<ILevel>
            {
                new Level("world1-1-test.csv", this)
            };

            CurrentLevel = levels[0];
            startEndOfLevelMusic = false;
            startGameOverMusic = false;
        }

        private void InitializeCamera()
        {
            camera = new BasicCamera(cameraStartLocation, CurrentLevel);
            cameraController = new BasicCameraController(camera, players);
        }

        private void EndLevel(GameTime gameTime)
        {
            if (!startEndOfLevelMusic)
            {
                MediaPlayer.Play(SoundFactory.Instance.Endgame());
                startEndOfLevelMusic = true;
                gameMetricTracker.GameTimer.AddValue(-gameMetricTracker.GameTimer.Value);
            }

            endGameTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (endGameTimer > LEVELEND_RESET_TIMER)
            {
                endGameTimer -= LEVELEND_RESET_TIMER;
                new QuitGameCommand().Execute();
            }
        }

        private void GameOver(GameTime gameTime)
        {
            if (!startGameOverMusic)
            {
                MediaPlayer.Play(SoundFactory.Instance.Over());
                startGameOverMusic = true;
            }

            endGameTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (endGameTimer > GAMEOVER_RESET_TIMER)
            {
                endGameTimer -= GAMEOVER_RESET_TIMER;
                new QuitGameCommand().Execute();
            }
        }
    }
}
