using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Sprites.BlockSprites;
using SuperMarioBrothers.Sprites.EnvironmentObjectSprites;
using SuperMarioBrothers.Sprites.GoombaSprites;
using SuperMarioBrothers.Sprites.ItemSprites;
using SuperMarioBrothers.Sprites.KoopaSprites;
using SuperMarioBrothers.Sprites.MarioSprites.SmallMario;
using SuperMarioBrothers.Sprites.MarioSprites.FireMario;
using SuperMarioBrothers.Sprites.MarioSprites.BigMario;
using SuperMarioBrothers.Sprites.FireBallSprites;
using SuperMarioBrothers.Sprites.LuigiSprites.SmallLuigi;
using SuperMarioBrothers.Sprites.LuigiSprites.FireLuigi;
using SuperMarioBrothers.Sprites.LuigiSprites.BigLuigi;
using SuperMarioBrothers.Sprites.TitleScreenSprites;

namespace SuperMarioBrothers.Sprites
{
    public class SpriteFactory
    {
        private static SpriteFactory instance = new SpriteFactory();

        private Texture2D enemySpriteSheet;
        private Texture2D marioSpriteSheet;
        private Texture2D luigiSpriteSheet;
        private Texture2D itemSpriteSheet;
        private Texture2D environmentObjectSpriteSheet;
        private Texture2D blockSpriteSheet;
        private Texture2D titleSpriteSheet;

        private SpriteFactory()
        {
        }

        public static SpriteFactory Instance
        {
            get
            {
                return instance;
            }
        }

        public void LoadAllTextures(ContentManager contentManager)
        {
            enemySpriteSheet = contentManager.Load<Texture2D>("EnemySpriteSheets/smb_enemies_sheet");
            marioSpriteSheet = contentManager.Load<Texture2D>("MarioSpriteSheets/smb_mario_sheet");
            luigiSpriteSheet = contentManager.Load<Texture2D>("MarioSpriteSheets/smb_luigi_sheet");
            itemSpriteSheet = contentManager.Load<Texture2D>("ItemSpriteSheets/smb_items_sheet");
            environmentObjectSpriteSheet = contentManager.Load<Texture2D>("EnvironmentSpriteSheets/smb_scenery_sprites");
            blockSpriteSheet = contentManager.Load<Texture2D>("BlockSpriteSheets/BlockSprite");
            titleSpriteSheet = contentManager.Load<Texture2D>("TitleSpriteSheets/title_sprites");
        }

        #region EnemySprites
        public ISprite GetWalkingGoombaSprite()
        {
            return new WalkingGoombaSprite(enemySpriteSheet);
        }

        public ISprite GetDeadGoombaSprite()
        {
            return new DeadGoombaSprite(enemySpriteSheet);
        }

        public ISprite GetFlippedGoombaSprite()
        {
            return new FlippedGoombaSprite(enemySpriteSheet);
        }

        public ISprite GetLeftWalkingGreenKoopaSprite()
        {
            return new LeftWalkingGreenKoopaSprite(enemySpriteSheet);
        }

        public ISprite GetRightWalkingGreenKoopaSprite()
        {
            return new RightWalkingGreenKoopaSprite(enemySpriteSheet);
        }

        public ISprite GetDeadGreenKoopaSprite()
        {
            return new DeadGreenKoopaSprite(enemySpriteSheet);
        }

        public ISprite GetFlippedLeftGreenKoopaSprite()
        {
            return new FlippedLeftGreenKoopaSprite(enemySpriteSheet);
        }

        public ISprite GetFlippedRightGreenKoopaSprite()
        {
            return new FlippedRightGreenKoopaSprite(enemySpriteSheet);
        }
        #endregion EnemySprites

        #region ItemSprites

        public ISprite GetBigMushroomSprite()
        {
            return new BigMushroomSprite(itemSpriteSheet);
        }

        public ISprite GetOneUpMushroomSprite()
        {
            return new OneUpMushroomSprite(itemSpriteSheet);
        }

        public ISprite GetFireFlowerSprite()
        {
            return new FireFlowerSprite(itemSpriteSheet);
        }
        public ISprite GetCoinSprite()
        {
            return new CoinSprite(itemSpriteSheet);
        }
        public ISprite GetStarSprite()
        {
            return new StarSprite(itemSpriteSheet);
        }

        #endregion ItemSprites

        #region BlockSprites

        public ISprite GetQuestionBlockSprite()
        {
            return new QuestionBlockSprite(blockSpriteSheet);
        }

        public ISprite GetUsedBlockSprite()
        {
            return new UsedBlockSprite(blockSpriteSheet);
        }

        public ISprite GetHiddenBlockSprite()
        {
            return new HiddenBlockSprite(blockSpriteSheet);
        }

        public ISprite GetBrickBlockSprite()
        {
            return new BrickBlockSprite(blockSpriteSheet);
        }

        public ISprite GetBrokenBrickBlockSprite()
        {
            return new BrokenBrickBlockSprite(blockSpriteSheet);
        }

        public ISprite GetSolidBlock1Sprite()
        {
            return new SolidBlock1Sprite(blockSpriteSheet);
        }

        public ISprite GetSolidBlock2Sprite()
        {
            return new SolidBlock2Sprite(blockSpriteSheet);
        }

        public ISprite GetBlueSolidBlock1Sprite()
        {
            return new BlueSolidBlock1Sprite(blockSpriteSheet);
        }

        public ISprite GetBlueBrickBlockSprite()
        {
            return new BlueBrickBlockSprite(blockSpriteSheet);
        }

        #endregion BlockSprites

        #region EnvironmentObjectSprites

        public ISprite GetSmallPipeSprite()
        {
            return new SmallPipeSprite(environmentObjectSpriteSheet);
        }
        public ISprite GetCastleSprite()
        {
            return new CastleSprite(environmentObjectSpriteSheet);
        }
        public ISprite GetMediumPipeSprite()
        {
            return new MediumPipeSprite(environmentObjectSpriteSheet);
        }
        public ISprite GetLongPipeSprite()
        {
            return new LongPipeSprite(environmentObjectSpriteSheet);
        }
        public ISprite GetNonAnimatedFlagSprite()
        {
            return new NonAnimatedFlagSprite(environmentObjectSpriteSheet);
        }
        public ISprite GetAnimatedFlagSprite()
        {
            return new AnimatedFlagSprite(environmentObjectSpriteSheet);
        }
        public ISprite GetWrapLPipeSprite()
        {
            return new WarpLPipeSprite(environmentObjectSpriteSheet);
        }
        public ISprite GetMovingPlatformLargeSprite()
        {
            // The platforms are environment objects but have their sprite in
            // the block sprite sheet.
            return new MovingPlatformLargeSprite(blockSpriteSheet);
        }
        #endregion EnvironmentObjectSprites

        #region MarioSprites

        public ISprite GetDeadMarioSprite()
        {
            return new DeadMarioSprite(marioSpriteSheet);
        }
        public ISprite GetLeftRunningSmallMarioSprite()
        {
            return new LeftRunningSmallMarioSprite(marioSpriteSheet);
        }

        public ISprite GetRightRunningSmallMarioSprite()
        {
            return new RightRunningSmallMarioSprite(marioSpriteSheet);
        }

        public ISprite GetLeftIdleSmallMarioSprite()
        {
            return new LeftIdleSmallMarioSprite(marioSpriteSheet);
        }

        public ISprite GetRightIdleSmallMarioSprite()
        {
            return new RightIdleSmallMarioSprite(marioSpriteSheet);
        }

        public ISprite GetRightJumpingSmallMarioSprite()
        {
            return new RightJumpingSmallMarioSprite(marioSpriteSheet);
        }

        public ISprite GetLeftJumpingSmallMarioSprite()
        {
            return new LeftJumpingSmallMarioSprite(marioSpriteSheet);
        }

        public ISprite GetLeftIdleFireMarioSprite()
        {
            return new LeftIdleFireMarioSprite(marioSpriteSheet);
        }

        public ISprite GetLeftJumpingFireMarioSprite()
        {
            return new LeftJumpingFireMarioSprite(marioSpriteSheet);
        }

        public ISprite GetLeftRunningFireMarioSprite()
        {
            return new LeftRunningFireMarioSprite(marioSpriteSheet);
        }
        public ISprite GetLeftCrouchingFireMarioSprite()
        {
            return new LeftCrouchingFireMarioSprite(marioSpriteSheet);
        }

        public ISprite GetRightCrouchingFireMarioSprite()
        {
            return new RightCrouchingFireMarioSprite(marioSpriteSheet);
        }

        public ISprite GetRightIdleFireMarioSprite()
        {
            return new RightIdleFireMarioSprite(marioSpriteSheet);
        }

        public ISprite GetRightJumpingFireMarioSprite()
        {
            return new RightJumpingFireMarioSprite(marioSpriteSheet);
        }

        public ISprite GetRightRunningFireMarioSprite()
        {
            return new RightRunningFireMarioSprite(marioSpriteSheet);
        }

        public ISprite GetLeftIdleBigMarioSprite()
        {
            return new LeftIdleBigMarioSprite(marioSpriteSheet);
        }

        public ISprite GetLeftJumpingBigMarioSprite()
        {
            return new LeftJumpingBigMarioSprite(marioSpriteSheet);
        }

        public ISprite GetLeftRunningBigMarioSprite()
        {
            return new LeftRunningBigMarioSprite(marioSpriteSheet);
        }
        public ISprite GetLeftCrouchingBigMarioSprite()
        {
            return new LeftCrouchingBigMarioSprite(marioSpriteSheet);
        }

        public ISprite GetRightCrouchingBigMarioSprite()
        {
            return new RightCrouchingBigMarioSprite(marioSpriteSheet);
        }

        public ISprite GetRightIdleBigMarioSprite()
        {
            return new RightIdleBigMarioSprite(marioSpriteSheet);
        }

        public ISprite GetRightJumpingBigMarioSprite()
        {
            return new RightJumpingBigMarioSprite(marioSpriteSheet);
        }

        public ISprite GetRightRunningBigMarioSprite()
        {
            return new RightRunningBigMarioSprite(marioSpriteSheet);
        }

        #endregion MarioSprites

        #region LuigiSprites

        public ISprite GetDeadLuigiSprite()
        {
            return new DeadLuigiSprite(luigiSpriteSheet);
        }
        public ISprite GetLeftRunningSmallLuigiSprite()

        {
            return new LeftRunningSmallLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetRightRunningSmallLuigiSprite()
        {
            return new RightRunningSmallLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetLeftIdleSmallLuigiSprite()
        {
            return new LeftIdleSmallLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetRightIdleSmallLuigiSprite()
        {
            return new RightIdleSmallLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetRightJumpingSmallLuigiSprite()
        {
            return new RightJumpingSmallLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetLeftJumpingSmallLuigiSprite()
        {
            return new LeftJumpingSmallLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetLeftIdleFireLuigiSprite()
        {
            return new LeftIdleFireLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetLeftJumpingFireLuigiSprite()
        {
            return new LeftJumpingFireLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetLeftRunningFireLuigiSprite()
        {
            return new LeftRunningFireLuigiSprite(luigiSpriteSheet);
        }
        public ISprite GetLeftCrouchingFireLuigiSprite()
        {
            return new LeftCrouchingFireLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetRightCrouchingFireLuigiSprite()
        {
            return new RightCrouchingFireLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetRightIdleFireLuigiSprite()
        {
            return new RightIdleFireLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetRightJumpingFireLuigiSprite()
        {
            return new RightJumpingFireLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetRightRunningFireLuigiSprite()
        {
            return new RightRunningFireLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetLeftIdleBigLuigiSprite()
        {
            return new LeftIdleBigLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetLeftJumpingBigLuigiSprite()
        {
            return new LeftJumpingBigLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetLeftRunningBigLuigiSprite()
        {
            return new LeftRunningBigLuigiSprite(luigiSpriteSheet);
        }
        public ISprite GetLeftCrouchingBigLuigiSprite()
        {
            return new LeftCrouchingBigLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetRightCrouchingBigLuigiSprite()
        {
            return new RightCrouchingBigLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetRightIdleBigLuigiSprite()
        {
            return new RightIdleBigLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetRightJumpingBigLuigiSprite()
        {
            return new RightJumpingBigLuigiSprite(luigiSpriteSheet);
        }

        public ISprite GetRightRunningBigLuigiSprite()
        {
            return new RightRunningBigLuigiSprite(luigiSpriteSheet);
        }

        #endregion LuigiSprites

        #region FireBallSprites

        public ISprite GetRollingFireBallSprite()
        {
            return new RollingFireBallSprite(blockSpriteSheet);
        }

        public ISprite GetExplodingFireBallSprite()
        {
            return new ExplodingFireBallSprite(blockSpriteSheet);
        }

        #endregion FireBallSprites

        public ISprite GetTitleScreenCursorSprite()
        {
            return new TitleScreenCursorSprite(titleSpriteSheet);
        }

        public ISprite GetTitleScreenTitleSprite()
        {
            return new TitleScreenTitleSprite(titleSpriteSheet);
        }

        public ISprite GetCoinCounterSprite()
        {
            return new CoinCounterSprite(blockSpriteSheet);
        }
    }
}
