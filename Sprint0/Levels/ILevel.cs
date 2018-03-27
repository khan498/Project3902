using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.EnvironmentObjects;
using SuperMarioBrothers.Items;
using SuperMarioBrothers.Projectile;
using SuperMarioBrothers.Warps;
using System.Collections.Generic;

namespace SuperMarioBrothers.Levels
{
    public interface ILevel
    {
        List<IEnemy> Enemies { get; }
        List<IBlock> Blocks { get; }
        List<IItem> Items { get; }
        List<IEnvironmentObject> EnvironmentObjects { get; }
        List<IProjectile> Projectiles { get; }
        List<IWarp> Warps { get; }
        List<IPlayer> Players { get; }

        Texture2D BackgroundImage { get; }

        bool IsEndOfLevel { get; }
        bool IsUnderground { get; set; }

        string Filename { get; }

        string WorldNumber { get; set; }

        int Height { get; set; }

        int Width { get; set; }

        int TimeLimitSeconds { get; set; }

        void ShootFireBall(IPlayer player);

        void EndLevel();

        void AddCoinInBlock(IBlock block);

        void Update(GameTime gameTime);
    }
}
