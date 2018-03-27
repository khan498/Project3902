using Microsoft.Xna.Framework;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Items;
using SuperMarioBrothers.Entities.Enemies;
using System.Collections.Generic;
using System;

namespace SuperMarioBrothers.Levels
{
    public class LevelAdjuster
    {
        public LevelAdjuster()
        {
        }

        public void AdjustBlocks(IBlock block, List<IBlock> Blocks)
        {
            Vector2 location = new Vector2(block.DestinationRectangle.X, block.DestinationRectangle.Y);

            if (block is BrickBlock && block.IsRemovable)
            {
                Blocks.Remove(block);
            }
            else if ((block is QuestionBlock || block is HiddenBlock || block is SpecialBrickBlock) && block.IsRemovable)
            {
                Blocks.Remove(block);
                Blocks.Add(new UsedBlock(location));
            }
        }

        public void AdjustMushrooms(IItem item, List<IItem> Items)
        {
            if ((MarioGame.Instance.CurrentGameMode.Players[0].IsMarioBig() || MarioGame.Instance.CurrentGameMode.Players[0].IsMarioFire()) && item is BigMushroom && !item.IsActivated)
            {
                Vector2 itemLocation = new Vector2(item.DestinationRectangle.X, item.DestinationRectangle.Y);
                Items.Remove(item);
                Items.Add(new FireFlower(itemLocation));
            }
            else if (MarioGame.Instance.CurrentGameMode.Players[0].IsMarioSmall() && item is FireFlower && !item.IsActivated)
            {
                Vector2 itemLocation = new Vector2(item.DestinationRectangle.X, item.DestinationRectangle.Y);
                Items.Remove(item);
                Items.Add(new BigMushroom(itemLocation));
            }
        }

        public void RemoveActivatedCoins(IItem item, List<IItem> Items)
        {
            if (item.IsActivated && item is Coin)
            {
                Items.Remove(item);
            }
        }
    }
}
