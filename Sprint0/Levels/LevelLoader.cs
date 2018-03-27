using Microsoft.Xna.Framework;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.EnvironmentObjects;
using SuperMarioBrothers.Items;
using SuperMarioBrothers.Level_Files;
using System;
using System.Collections.Generic;
using System.IO;

namespace SuperMarioBrothers.Levels
{
    public class LevelLoader
    {
        public const int blockSize = DataLibrary.DEFAULT_SIZE;
        private const string levelDirectory = "./Level_Files";
        private const int COIN_OFFSET = DataLibrary.COIN_OFFSET;

        public enum BlockIDs
        {
            Air = 0,
            SolidBlock1 = 1,
            SolidBlock2 = 2,
            BrickBlock = 3,
            HiddenBlock = 4,
            QuestionBlock = 5,
            UsedBlock = 6,
            SpecialBrickBlock = 7,
            BlueSolidBlock1 = 8,
            BlueBrickBlock = 9
        }

        public enum EnemyIDs
        {
            NoEnemy = 0,
            Goomba = 1,
            GreenKoopa = 2
        }

        public enum ItemIDs
        {
            NoItem = 0,
            BigMushroom = 1,
            Coin = 2,
            FireFlower = 3,
            OneUpMushroom = 4,
            Star = 5,
            FloatingCoin = 6
        }

        public enum EnvironmentObjectIDs
        {
            NoEnvironmentObject = 0,
            SmallPipe = 1,
            MediumPipe = 2,
            LongPipe = 3,
            Castle = 4,
            Flag = 5,
            WarpLPipe = 6,
            WarpLongPipe = 7,
            MovingPlatformLarge = 8,
            EnemySpawnPipe = 9
        }

        public LevelLoader()
        {

        }

        public void LoadLevel(ILevel level)
        {
            int y = 0;
            FileStream fs = File.Open(levelDirectory + "/" + level.Filename, FileMode.Open, FileAccess.Read);
            BufferedStream bs = new BufferedStream(fs);
            //StreamReader reader = new StreamReader(levelDirectory + "/" + level.Filename);
            StreamReader reader = new StreamReader(bs);

            string line = reader.ReadLine();
            string[] info = line.Split(',');

            level.Width = Convert.ToInt32(info[1]);
            level.Height = Convert.ToInt32(info[2]);
            level.WorldNumber = info[3];
            level.TimeLimitSeconds = Convert.ToInt32(info[4]);

            while (y < level.Height)
            {
                level.Blocks.AddRange(CreateBlocksForRow(reader.ReadLine(), y));
                y++;
            }

            reader.ReadLine();
            y = 0;

            while (y < level.Height)
            {
                level.Enemies.AddRange(CreateEnemiesForRow(reader.ReadLine(), y));
                y++;
            }

            reader.ReadLine();
            y = 0;

            while (y < level.Height)
            {
                level.EnvironmentObjects.AddRange(CreateEnvironmentObjectsForRow(reader.ReadLine(), y));
                y++;
            }

            reader.ReadLine();
            y = 0;

            while (y < level.Height)
            {
                level.Items.AddRange(CreateItemsForRow(reader.ReadLine(), y));
                y++;
            }

            reader.Close();
        }

        private List<IBlock> CreateBlocksForRow(string line, int y)
        {
            int x = 0;

            List<IBlock> blocks = new List<IBlock>();

            string[] blockIDs = line.Split(',');

            foreach (string id in blockIDs)
            {
                int blockID = Convert.ToInt32(id);
                Vector2 blockLocation = new Vector2(x * blockSize, y * blockSize);

                switch (blockID)
                {
                    case ((int) BlockIDs.Air):
                        {
                            break;
                        }

                    case ((int) BlockIDs.SolidBlock1):
                        {
                            blocks.Add(new SolidBlock1(blockLocation));
                            break;
                        }

                    case ((int) BlockIDs.SolidBlock2):
                        {
                            blocks.Add(new SolidBlock2(blockLocation));
                            break;
                        }

                    case ((int) BlockIDs.BrickBlock):
                        {
                            blocks.Add(new BrickBlock(blockLocation));
                            break;
                        }

                    case ((int) BlockIDs.HiddenBlock):
                        {
                            blocks.Add(new HiddenBlock(blockLocation));
                            break;
                        }

                    case ((int) BlockIDs.QuestionBlock):
                        {
                            blocks.Add(new QuestionBlock(blockLocation));
                            break;
                        }

                    case ((int) BlockIDs.UsedBlock):
                        {
                            blocks.Add(new UsedBlock(blockLocation));
                            break;
                        }

                    case ((int)BlockIDs.SpecialBrickBlock):
                        {
                            blocks.Add(new SpecialBrickBlock(blockLocation));
                            break;
                        }

                    case ((int) BlockIDs.BlueSolidBlock1):
                        {
                            blocks.Add(new BlueSolidBlock1(blockLocation));
                            break;
                        }

                    case ((int) BlockIDs.BlueBrickBlock):
                        {
                            blocks.Add(new BlueBrickBlock(blockLocation));
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }

                x++;
            }

            return blocks;
        }

        private List<IEnemy> CreateEnemiesForRow(string line, int y)
        {
            int x = 0;

            List<IEnemy> enemies = new List<IEnemy>();

            string[] enemyIDs = line.Split(',');

            foreach (string id in enemyIDs)
            {
                int enemyID = Convert.ToInt32(id);
                Vector2 enemyLocation = new Vector2(x * blockSize, y * blockSize);

                switch (enemyID)
                {
                    case ((int)EnemyIDs.NoEnemy):
                        {
                            break;
                        }

                    case ((int)EnemyIDs.Goomba):
                        {
                            enemies.Add(new Goomba(enemyLocation));
                            break;
                        }

                    case ((int)EnemyIDs.GreenKoopa):
                        {
                            enemies.Add(new GreenKoopa(enemyLocation));
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }

                x++;
            }

            return enemies;
        }

        private List<IItem> CreateItemsForRow(string line, int y)
        {
            int x = 0;

            List<IItem> items = new List<IItem>();

            string[] itemIDs = line.Split(',');

            foreach (string id in itemIDs)
            {
                int itemID = Convert.ToInt32(id);
                Vector2 itemLocation = new Vector2(x * blockSize, y * blockSize);

                switch (itemID)
                {
                    case ((int)ItemIDs.NoItem):
                        {
                            break;
                        }

                    case ((int)ItemIDs.BigMushroom):
                        {
                            items.Add(new BigMushroom(itemLocation));
                            break;
                        }

                    case ((int)ItemIDs.Coin):
                        {
                            Vector2 coinLocation = new Vector2(itemLocation.X + COIN_OFFSET, itemLocation.Y);
                            items.Add(new Coin(coinLocation));
                            break;
                        }

                    case ((int)ItemIDs.FireFlower):
                        {
                            items.Add(new FireFlower(itemLocation));
                            break;
                        }

                    case ((int)ItemIDs.OneUpMushroom):
                        {
                            items.Add(new OneUpMushroom(itemLocation));
                            break;
                        }

                    case ((int)ItemIDs.Star):
                        {
                            items.Add(new Star(itemLocation));
                            break;
                        }

                    case ((int)ItemIDs.FloatingCoin):
                        {
                            Vector2 coinLocation = new Vector2(itemLocation.X + COIN_OFFSET, itemLocation.Y);
                            items.Add(new FloatingCoin(coinLocation));
                            break;
                        }

                    default:
                        {
                            break;
                        }
                }

                x++;
            }
            return items;
        }

        private List<IEnvironmentObject> CreateEnvironmentObjectsForRow(string line, int y)
        {
            int x = 0;

            List<IEnvironmentObject> environmentObjects = new List<IEnvironmentObject>();

            string[] environmentObjectIDs = line.Split(',');

            foreach (string id in environmentObjectIDs)
            {
                int environmentObjectID = Convert.ToInt32(id);
                Vector2 environmentObjectLocation = new Vector2(x * blockSize, y * blockSize);

                switch (environmentObjectID)
                {
                    case ((int)EnvironmentObjectIDs.NoEnvironmentObject):
                        {
                            break;
                        }

                    case ((int)EnvironmentObjectIDs.SmallPipe):
                        {
                            environmentObjects.Add(new SmallPipe(environmentObjectLocation));
                            break;
                        }

                    case ((int)EnvironmentObjectIDs.MediumPipe):
                        {
                            environmentObjects.Add(new MediumPipe(environmentObjectLocation));
                            break;
                        }

                    case ((int)EnvironmentObjectIDs.LongPipe):
                        {
                            environmentObjects.Add(new LongPipe(environmentObjectLocation));
                            break;
                        }

                    case ((int)EnvironmentObjectIDs.Castle):
                        {
                            environmentObjects.Add(new Castle(environmentObjectLocation));
                            break;
                        }

                    case ((int)EnvironmentObjectIDs.Flag):
                        {
                            environmentObjects.Add(new Flag(environmentObjectLocation));
                            break;
                        }

                    case ((int)EnvironmentObjectIDs.WarpLPipe):
                        {
                            environmentObjects.Add(new WarpLPipe(environmentObjectLocation));
                            break;
                        }
                    case ((int)EnvironmentObjectIDs.WarpLongPipe):
                        {
                            environmentObjects.Add(new WarpLongPipe(environmentObjectLocation));
                            break;
                        }
                    case ((int)EnvironmentObjectIDs.MovingPlatformLarge):
                        {
                            environmentObjects.Add(new MovingPlatformLarge(environmentObjectLocation, 48));
                            break;
                        }
                    case ((int)EnvironmentObjectIDs.EnemySpawnPipe):
                        {
                            environmentObjects.Add(new EnemySpawnPipe(environmentObjectLocation));
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }

                x++;
            }
            return environmentObjects;
        }
    }
}
