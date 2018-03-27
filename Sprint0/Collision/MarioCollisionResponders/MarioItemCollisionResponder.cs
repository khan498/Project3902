using SuperMarioBrothers.Items;
using SuperMarioBrothers.Entities.Mario;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using SuperMarioBrothers.Sounds;
using Microsoft.Xna.Framework.Media;

namespace SuperMarioBrothers.Collision.MarioCollisionResponders
{
    public class MarioItemCollisionResponder
    {
        public MarioItemCollisionResponder()
        {
        }

        public void HandleCollision(IPlayer mario, IItem item, Side side, List<IItem> Items)
        {
            Rectangle marioRectangle = mario.DestinationRectangle;
            Rectangle itemRectangle = item.DestinationRectangle;
            Rectangle intersect = Rectangle.Intersect(marioRectangle, itemRectangle);

            int height = mario.DestinationRectangle.Height;
            int width = mario.DestinationRectangle.Width;

            if ((side.Equals(Side.Bottom) || side.Equals(Side.BottomLeft) || side.Equals(Side.BottomRight)) && !item.IsActivated)
            {
                item.IsTransparent = false;
                item.RiseUp();
                if (item is Coin)
                {
                    SoundFactory.Instance.CoinSound();
                    MarioGame.Instance.CurrentGameMode.GameMetric.CoinCounter.AddValue(1);
                    MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.CoinScore(item.DestinationRectangle.X, item.DestinationRectangle.Y);
                }
                else if (item is BigMushroom)
                {
                    SoundFactory.Instance.PowerUpAppearSound();
                }
                else if (item is FireFlower)
                {
                    SoundFactory.Instance.PowerUpAppearSound();
                }
                else if (item is Star)
                {
                    SoundFactory.Instance.PowerUpAppearSound();
                }
                else if (item is OneUpMushroom)
                {
                    SoundFactory.Instance.PowerUpAppearSound();
                }
                mario.DestinationRectangle = new Rectangle(marioRectangle.X, marioRectangle.Y + intersect.Height , width, height);
            }

            if (item.IsActivated)
            {
                if (item is BigMushroom)
                {
                    if (mario.IsMarioSmall())
                        mario.BeBig();
                    SoundFactory.Instance.PowerUpSound();

                    MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.PowerUpScore(item.DestinationRectangle.X, item.DestinationRectangle.Y);
                    Items.Remove(item);
                }
                else if (item is FireFlower)
                {
                    mario.BeFire();
                    SoundFactory.Instance.PowerUpSound();
                    MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.PowerUpScore(item.DestinationRectangle.X, item.DestinationRectangle.Y);
                    Items.Remove(item);
                }
                else if (item is Star)
                {
                    MarioGame.Instance.CurrentGameMode.Players[0] = new StarMario(mario);
                    MediaPlayer.Play(SoundFactory.Instance.Starman());
                    MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.PowerUpScore(item.DestinationRectangle.X, item.DestinationRectangle.Y);
                    Items.Remove(item);
                }
                else if (item is Coin)
                {
                    Items.Remove(item);
                }
                else if (item is OneUpMushroom)
                {
                    SoundFactory.Instance.OneUpSound();
                    Items.Remove(item);
                    mario.AddLives(1);
                }
                else if (item is FloatingCoin)
                {
                    SoundFactory.Instance.CoinSound();
                    MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.CoinScore(item.DestinationRectangle.X, item.DestinationRectangle.Y);
                    MarioGame.Instance.CurrentGameMode.GameMetric.CoinCounter.AddValue(1);
                    Items.Remove(item);
                }
            }
        }
    }
}
