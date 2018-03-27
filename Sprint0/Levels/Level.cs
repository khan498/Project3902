using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Collision.CollisionDetectors;
using SuperMarioBrothers.CollisionDectorAndResponder.Collision.CollisionDetectors;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.EnvironmentObjects;
using SuperMarioBrothers.Items;
using SuperMarioBrothers.Physics;
using SuperMarioBrothers.Projectile;
using SuperMarioBrothers.Warps;
using SuperMarioBrothers.GameModes;
using System.Collections.Generic;
using System;

namespace SuperMarioBrothers.Levels
{
    public class Level : ILevel
    {
        private const int TIME_LIMIT_SEC = 400;

        private string filename;
        private string worldNumber;

        private int height;
        private int width;

        private Texture2D backgroundImage;

        private MarioCollisionDetector marioCollisionDetector;
        private EnemyCollisionDetector enemyCollisionDetector;
        private ItemCollisionDetector ItemCollisionDetector;
        private ProjectileCollisionDetector projectileCollisionDetector;

        private LevelAdjuster levelAdjuster;
        private EndOfLevelAnimaton endOfLevelAnimaton;
        private bool endOfLevel = false;
        private bool isUnderground = false;

        private List<IBlock> blocks;
        private List<IEnemy> enemies;
        private List<IItem> items;
        private List<IEnvironmentObject> environmentObjects;
        private List<IProjectile> projectiles;
        private List<IWarp> warps;

        private IGameMode gameMode;
        private IPhysicsManager projectilePhysicsManager;

        private int timeLimitSeconds;

        public List<IEnemy> Enemies
        {
            get { return enemies; }
        }

        public List<IBlock> Blocks
        {
            get { return blocks; }
        }

        public List<IItem> Items
        {
            get { return items; }
        }

        public List<IEnvironmentObject> EnvironmentObjects
        {
            get { return environmentObjects; }
        }

        public List<IProjectile> Projectiles
        {
            get { return projectiles; }
        }

        public List<IWarp> Warps
        {
            get { return warps; }
        }
        public List<IPlayer> Players
        {
            get { return gameMode.Players; }
        }

        public bool IsEndOfLevel
        {
            get { return endOfLevel; }
        }

        public bool IsUnderground
        {
            get { return isUnderground; }
            set { isUnderground = value; }
        }

        public string Filename
        {
            get { return filename; }
        }

        public string WorldNumber
        {
            get { return worldNumber; }
            set { worldNumber = value; }
        }

        public int Height
        {
            get { return height; }
            set { height = value; }
        }

        public int Width
        {
            get { return width; }
            set { width = value; }
        }

        public Texture2D BackgroundImage
        {
            get { return backgroundImage; }
        }

        public int TimeLimitSeconds
        {
            get { return timeLimitSeconds; }
            set { timeLimitSeconds = value; }
        }

        public Level(string filename, IGameMode gameMode)
        {
            this.filename = filename;
            this.gameMode = gameMode;
            blocks = new List<IBlock>();
            enemies = new List<IEnemy>();
            items = new List<IItem>();
            environmentObjects = new List<IEnvironmentObject>();
            projectiles = new List<IProjectile>();
            warps = new List<IWarp>();

            marioCollisionDetector = new MarioCollisionDetector();
            enemyCollisionDetector = new EnemyCollisionDetector();
            ItemCollisionDetector = new ItemCollisionDetector();
            projectileCollisionDetector = new ProjectileCollisionDetector();

            levelAdjuster = new LevelAdjuster();
            LoadLevel();

            projectilePhysicsManager = new ProjectilePhysicsManager();
        }

        public void ShootFireBall(IPlayer player)
        {
            if (projectiles.Count < 2)
            {
                if (player.IsFacingRight())
                {
                    Vector2 position = player.CurrentLocationVector;
                    position.X += 30;
                    position.Y += 10;
                    projectiles.Add(new FireBall(
                        position,
                        new Vector2(6, 3)
                    ));
                }
                else
                {
                    Vector2 position = player.CurrentLocationVector;
                    position.X -= 30;
                    position.Y += 10;
                    projectiles.Add(new FireBall(
                        position,
                        new Vector2(-6, -3)
                    ));
                }
            }
        }

        public void AddCoinInBlock(IBlock block)
        {
            Vector2 coinLocation = new Vector2(block.DestinationRectangle.X + 6, block.DestinationRectangle.Y);
            items.Add(new Coin(coinLocation));
        }

        public void EndLevel()
        {
            endOfLevel = true;
        }

        public void Update(GameTime gameTime)
        {
            int detectionOrder = new Random().Next();
            if (!endOfLevel)
            {
                DetectPlayerCollision(detectionOrder);
                UpdateBlocks(gameTime);
                UpdateEnemies(gameTime);
                UpdateItems(gameTime);
                UpdateEnvironmentObjects(gameTime);
                UpdateProjectiles(gameTime);
            }
            else
            {
                DetectPlayerCollision(detectionOrder);
                UpdateEnvironmentObjects(gameTime);
                endOfLevelAnimaton.Animate();
            }
        }

        private void LoadLevel()
        {
            backgroundImage = MarioGame.Instance.Content.Load<Texture2D>("BackgroundImages/w1_1_background");

            LevelLoader levelLoader = new LevelLoader();
            WarpLoader warpLoader = new WarpLoader();

            levelLoader.LoadLevel(this);
            warpLoader.LoadWarps(this, "world1-1_warps.csv");

            endOfLevelAnimaton = new EndOfLevelAnimaton(MarioGame.Instance.CurrentGameMode.Players[0], this);
        }

        private void UpdateBlocks(GameTime gameTime)
        {
            foreach (IBlock block in Blocks.ToArray())
            {
                levelAdjuster.AdjustBlocks(block, Blocks);
                block.Update(gameTime);
            }
        }

        private void UpdateEnemies(GameTime gameTime)
        {
            foreach (IEnemy enemy in Enemies.ToArray())
            {
                if (enemy.IsActivated)
                {
                    enemy.Update(gameTime);
                    enemyCollisionDetector.DetectCollisions(this, enemy);
                }
            }
        }

        private void UpdateItems(GameTime gameTime)
        {
            foreach (IItem item in Items.ToArray())
            {
                if (gameMode is ClassicGameMode)
                {
                    levelAdjuster.AdjustMushrooms(item, Items);
                }
                levelAdjuster.RemoveActivatedCoins(item, Items);
                ItemCollisionDetector.DetectCollisions(this, item);
                item.Update(gameTime);
            }
        }

        private void UpdateEnvironmentObjects(GameTime gameTime)
        {
            foreach (IEnvironmentObject environmentObject in EnvironmentObjects)
            {
                environmentObject.Update(gameTime);
            }
        }

        private void UpdateProjectiles(GameTime gameTime)
        {
            foreach (IProjectile projectile in Projectiles.ToArray())
            {
                if (!projectile.IsActive)
                {
                    Projectiles.Remove(projectile);
                }
                else
                {
                    projectilePhysicsManager.ApplyPhysics(projectile);
                    projectile.Update(gameTime);
                }
            }

            projectileCollisionDetector.DetectCollisions(this);
        }

        private void DetectPlayerCollision(int detectionOnder)
        {
            if (detectionOnder % 2 == 0 && gameMode is ArenaGameMode)
            {
                marioCollisionDetector.DetectCollisions(this, Players[1]);
                marioCollisionDetector.DetectCollisions(this, Players[0]);
            }
            else if (detectionOnder % 2 != 0 && gameMode is ArenaGameMode)
            {
                marioCollisionDetector.DetectCollisions(this, Players[0]);
                marioCollisionDetector.DetectCollisions(this, Players[1]);
            }
            else
            {
                marioCollisionDetector.DetectCollisions(this, Players[0]);
            }
        }
    }
}
