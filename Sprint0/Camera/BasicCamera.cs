using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.EnvironmentObjects;
using SuperMarioBrothers.Items;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Levels;
using SuperMarioBrothers.Projectile;

namespace SuperMarioBrothers.Camera
{
    class BasicCamera : ICamera
    {
        private const int TILE_SIZE = DataLibrary.DEFAULT_SIZE;
        private static Vector2 origin = new Vector2(0, 0);

        private ILevel currentLevel;

        private int width;
        private int height;

        private Vector2 topLeftWorldSpace;

        private int leftBoundaryX;
        private int rightBoundaryX;

        private Vector2 center;

        private bool isAtLeftEdgeOfLevel;
        private bool isAtRightEdgeOfLevel;

        public Vector2 TopLeftWorldSpace
        {
            get
            {
                return topLeftWorldSpace;
            }

            set
            {
                topLeftWorldSpace = value;
            }
        }
        public Vector2 OffsetVector
        {
            get
            {
                return topLeftWorldSpace;
            }
        }
        public Vector2 Center
        {
            get
            {
                return center;
            }
        }
        public ILevel CurrentLevel
        {
            get
            {
                return currentLevel;
            }

            set
            {
                currentLevel = value;
            }
        }

        public int Width
        {
            get
            {
                return width;
            }

            set
            {
                width = value;
            }
        }
        public int Height
        {
            get
            {
                return height;
            }

            set
            {
                height = value;
            }
        }

        public int LeftBoundaryX
        {
            get
            {
                return leftBoundaryX;
            }
        }

        public int RightBoundaryX
        {
            get
            {
                return rightBoundaryX;
            }
        }

        public bool IsAtLeftEdgeOfLevel
        {
            get
            {
                return isAtLeftEdgeOfLevel;
            }
        }

        public bool IsAtRightEdgeOfLevel
        {
            get
            {
                return isAtRightEdgeOfLevel;
            }
        }

        public BasicCamera(Vector2 topLeftWorldSpace, ILevel currentLevel)
        {
            Initialize(topLeftWorldSpace, currentLevel);
        }

        public void Update()
        {
            RecalculateCameraValues();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (MarioGame.Instance.CurrentGameMode.CurrentLevel.IsUnderground)
            {
                MarioGame.Instance.GraphicsDevice.Clear(Color.Black);
            }
            else
            {
                spriteBatch.Begin();
                spriteBatch.Draw(CurrentLevel.BackgroundImage, new Rectangle(0, 0, Width, Height), Color.White);
                spriteBatch.End();
            }


            DrawItems(spriteBatch);
            DrawEnemies(spriteBatch);
            DrawEnvironmentObjects(spriteBatch);
            DrawBlocks(spriteBatch);
            DrawProjectiles(spriteBatch);
            MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.Draw(spriteBatch, OffsetVector);

            DrawHud();
        }

        public void ScrollLeft(int pixelsToScroll)
        {
            if (Vector2.Add(TopLeftWorldSpace, new Vector2(pixelsToScroll, 0)).X < 0)
            {
                isAtLeftEdgeOfLevel = true;
                TopLeftWorldSpace = new Vector2(0, TopLeftWorldSpace.Y);
            }
            else
            {
                isAtLeftEdgeOfLevel = false;
                TopLeftWorldSpace = Vector2.Add(TopLeftWorldSpace, new Vector2(pixelsToScroll, 0));
            }
        }

        public void ScrollRight(int pixelsToScroll)
        {
            if (Vector2.Add(new Vector2(TopLeftWorldSpace.X + Width), new Vector2(pixelsToScroll, 0)).X > CurrentLevel.Width * TILE_SIZE)
            {
                isAtRightEdgeOfLevel = true;
                TopLeftWorldSpace = new Vector2((CurrentLevel.Width * TILE_SIZE) - Width, TopLeftWorldSpace.Y);
            }
            else
            {
                isAtRightEdgeOfLevel = false;
                TopLeftWorldSpace = Vector2.Add(TopLeftWorldSpace, new Vector2(pixelsToScroll, 0));
            }
        }

        private void Initialize(Vector2 topLeftWorldSpace, ILevel currentLevel)
        {
            this.topLeftWorldSpace = topLeftWorldSpace;
            this.currentLevel = currentLevel;

            width = 25 * TILE_SIZE;
            height = 15 * TILE_SIZE;

            RecalculateCameraValues();
        }

        private void DrawBlocks(SpriteBatch spriteBatch)
        {
            foreach (IBlock block in CurrentLevel.Blocks)
            {
                block.Draw(spriteBatch, OffsetVector);
            }
        }

        private void DrawEnemies(SpriteBatch spriteBatch)
        {
            foreach (IEnemy enemy in CurrentLevel.Enemies)
            {
                enemy.Draw(spriteBatch, OffsetVector);
            }
        }

        private void DrawItems(SpriteBatch spriteBatch)
        {
            foreach (IItem item in CurrentLevel.Items)
            {
                item.Draw(spriteBatch, OffsetVector);
            }
        }

        private void DrawEnvironmentObjects(SpriteBatch spriteBatch)
        {
            foreach (IEnvironmentObject obj in CurrentLevel.EnvironmentObjects)
            {
                obj.Draw(spriteBatch, OffsetVector);
            }
        }

        private void DrawProjectiles(SpriteBatch spriteBatch)
        {
            foreach (IProjectile projectile in CurrentLevel.Projectiles)
            {
                projectile.Draw(spriteBatch, OffsetVector);
            }
        }

        private void RecalculateCameraValues()
        {
            center = new Vector2(topLeftWorldSpace.X + (width / 2), topLeftWorldSpace.Y + (height / 2));
            leftBoundaryX = (int)center.X - (TILE_SIZE * 2);
            rightBoundaryX = (int)center.X + (TILE_SIZE * 2);
        }

        private void DrawHud()
        {

        }
    }
}
