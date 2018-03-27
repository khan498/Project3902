using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Controllers;
using SuperMarioBrothers.Sprites;
using SuperMarioBrothers.SpriteFonts;
using SuperMarioBrothers.Sounds;
using SuperMarioBrothers.GameModes;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Screens;
using System.Collections.Generic;

namespace SuperMarioBrothers
{
    public class MarioGame : Game
    {
        private static MarioGame instance = new MarioGame();

        private bool downIsBeingPressed = false;
        private bool rightIsBeingPressed = false;

        public bool DownIsBeingPressed
        {
            get { return downIsBeingPressed; }
            set { downIsBeingPressed = value; }
        }

        public bool RightIsBeingPressed
        {
            get { return rightIsBeingPressed; }
            set { rightIsBeingPressed = value; }
        }

        private MarioGame()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        public static MarioGame Instance
        {
            get { return instance; }
        }

        private SpriteBatch spriteBatch;
        private GraphicsDeviceManager graphics;

        private MouseController mouse;

        private IGameMode currentGameMode;
        private IScreen currentScreen;

        private bool isShowingStartScreen = true;

        public bool IsShowingStartScreen
        {
            get
            {
                return isShowingStartScreen;
            }

            set
            {
                isShowingStartScreen = value;
            }
        }

        public IScreen CurrentScreen
        {
            get
            {
                return currentScreen;
            }

            set
            {
                currentScreen = value;
            }
        }

        public IGameMode CurrentGameMode
        {
            get { return currentGameMode; }
            set
            {
                currentGameMode = value;
                currentGameMode.InitializeGameMode();
            }
        }

        protected override void LoadContent()
        {
            SpriteFactory.Instance.LoadAllTextures(Content);
            SpriteFontFactory.Instance.LoadAllFonts(Content);
            SoundFactory.Instance.LoadSound(Content);

            spriteBatch = new SpriteBatch(GraphicsDevice);
            mouse = MouseController.Instance;

            currentScreen = new StartScreen();
        }

        public void HardResetGame()
        {
            currentGameMode.HardReset();
        }
        public void SoftResetGame()
        {
            currentGameMode.SoftReset();
        }

        public void PauseGame()
        {
            currentGameMode.Pause();
        }
        public void UnpauseGame()
        {
            currentGameMode.Unpause();
        }

        protected override void UnloadContent()
        {
            Content.Unload();
        }

        protected override void Update(GameTime gameTime)
        {
            if (isShowingStartScreen)
            {
                currentScreen.Update(gameTime);
            }
            else
            {
                currentGameMode.Update(gameTime);

                if (!CurrentGameMode.IsPaused)
                {
                    mouse.Update(gameTime);
                }
                base.Update(gameTime);
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            if (isShowingStartScreen)
            {
                currentScreen.Draw(spriteBatch);
            }
            else
            {
                currentGameMode.Draw(spriteBatch);
                base.Draw(gameTime);
            }
        }

    }
}
