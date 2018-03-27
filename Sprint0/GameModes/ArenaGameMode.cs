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
    public class ArenaGameMode : IGameMode
    {
        private const int STARTING_LIVES = DataLibrary.ARENA_LIVES;
        private const int GAMEOVER_RESET_TIMER = 7500;
        private const int INTERMEDIATE_SCREEN_TIMER = 3000;
        private const int ITEM_SPAWN_TIME = 12000;
        private const int ENEMY_SPAWN_TIME = 10000;
        private Vector2 enemySpawnLocation = new Vector2(384, 64);
        private Vector2 itemSpawnLocation = new Vector2(384, 416);
        private int elapsedTime;
        private int itemSpawnTimer;
        private int enemySpawnTimer;
        private int endGameTimer;

        private static Vector2 player1StartLocation = new Vector2(64, 384);
        private static Vector2 player2StartLocation = new Vector2(704, 384);
        private static Vector2 cameraStartLocation = new Vector2(0, 0);

        private Game currentGame;
        private List<IPlayer> players;

        private List<ILevel> levels;
        private ILevel currentLevel;
        private RandomObjectSpawner randomObjectSpawner;
        private bool isPaused = false;

        private IController player1Keyboard;
        private IController player2Keyboard;
        private IController player1Gamepad;
        private IController player2Gamepad;
        private ICameraController cameraController;

        private ICamera camera;
        private IHud hud;
        private GameMetricTracker gameMetricTracker;

        private bool showIntermediateScreen;
        private bool showWinnerScreen;
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
            get { return showWinnerScreen; }
            set { showWinnerScreen = value; }
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

        public ArenaGameMode(Game game)
        {
            currentGame = game;
        }

        public void InitializeGameMode()
        {
            InitializePlayer();
            InitializeLevels();
            gameMetricTracker = new GameMetricTracker(STARTING_LIVES, currentLevel.TimeLimitSeconds, true);

            player1Keyboard = new Player1KeyboardController(players[0]);
            player2Keyboard = new Player2KeyboardController(players[1]);
            player1Gamepad = new GamepadController(players[0]);
            player2Gamepad = new GamepadController(players[1]);

            hud = new ArenaHud(gameMetricTracker, CurrentLevel.WorldNumber);

            MediaPlayer.Play(SoundFactory.Instance.Fight());
            InitializeCamera();
            showWinnerScreen = false;
            itemSpawnTimer = 0;
            enemySpawnTimer = 0;
        }

        public void HardReset()
        {
            InitializeGameMode();
            MediaPlayer.Play(SoundFactory.Instance.Fight());
            elapsedTime = 0;
        }
        public void SoftReset()
        {
            InitializePlayer();
            InitializeLevels();
            gameMetricTracker.PartialReset();

            player1Keyboard = new Player1KeyboardController(players[0]);
            player2Keyboard = new Player2KeyboardController(players[1]);
            player1Gamepad = new GamepadController(players[0]);
            player2Gamepad = new GamepadController(players[1]);
            InitializeCamera();
            MediaPlayer.Play(SoundFactory.Instance.Fight());

            hud = new ArenaHud(gameMetricTracker, CurrentLevel.WorldNumber);
            elapsedTime = 0;
            itemSpawnTimer = 0;
            enemySpawnTimer = 0;
        }
        public void Pause()
        {
            if (!showIntermediateScreen && !showWinnerScreen)
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

            player1Keyboard.Update(gameTime);
            player1Gamepad.Update(gameTime);
            
            if (!IsPaused && !showIntermediateScreen && !showWinnerScreen)
            {
                GenerateRandomObjects(gameTime);
                MediaPlayer.Resume();
                player2Keyboard.Update(gameTime);
                player2Gamepad.Update(gameTime);
                players[0].Update(gameTime);
                players[1].Update(gameTime);
                CurrentLevel.Update(gameTime);
                cameraController.Update();
                hud.Update(gameTime);
            }
            if (showWinnerScreen)
            {
                GameOver(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (!showIntermediateScreen && !showWinnerScreen)
            {
                currentLevel.IsUnderground = true;
                camera.Draw(spriteBatch);
                players[0].Draw(spriteBatch, camera.OffsetVector);
                players[1].Draw(spriteBatch, camera.OffsetVector);
                hud.Draw(spriteBatch);
            }
            else if (showIntermediateScreen)
            {
                hud.DrawIntermediateScreen(spriteBatch);
            }
            else if (showWinnerScreen)
            {
                hud.DrawGameOverScreen(spriteBatch);
            }
        }

        private void InitializePlayer()
        {
            players = new List<IPlayer>
            {
                new Mario(player1StartLocation, true),
                new Mario(player2StartLocation, false)
            };
        }

        private void InitializeLevels()
        {
            levels = new List<ILevel>
            {
                new Level("arena.csv", this)
            };

            currentLevel = levels[0];
            startGameOverMusic = false;
            randomObjectSpawner = new RandomObjectSpawner(currentLevel);
        }

        private void InitializeCamera()
        {
            camera = new BasicCamera(cameraStartLocation, CurrentLevel);
            cameraController = new BasicCameraController(camera, players);
        }

        private void GameOver(GameTime gameTime)
        {
            if (!startGameOverMusic)
            {
                MediaPlayer.Play(SoundFactory.Instance.Endgame());
                startGameOverMusic = true;
            }

            endGameTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (endGameTimer > GAMEOVER_RESET_TIMER)
            {
                endGameTimer -= GAMEOVER_RESET_TIMER;
                new QuitGameCommand().Execute();
            }
        }

        private void GenerateRandomObjects(GameTime gameTime)
        {
            itemSpawnTimer += gameTime.ElapsedGameTime.Milliseconds;
            enemySpawnTimer += gameTime.ElapsedGameTime.Milliseconds;

            if (itemSpawnTimer >= ITEM_SPAWN_TIME)
            {
                randomObjectSpawner.GenerateRandomItems(itemSpawnLocation);
                itemSpawnTimer = 0;
            }
            if (enemySpawnTimer >= ENEMY_SPAWN_TIME)
            {
                randomObjectSpawner.GenerateRandomEnemy(enemySpawnLocation);
                enemySpawnTimer = 0;
            }
        }
    }
}
