using Microsoft.Xna.Framework;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.EnvironmentObjects;
using SuperMarioBrothers.Sounds;
using SuperMarioBrothers.Warps;
using Microsoft.Xna.Framework.Media;

using System;

namespace SuperMarioBrothers.Collision.MarioCollisionResponders
{
    public class MarioEnvironmentObjectCollisionResponder
    {
	    public MarioEnvironmentObjectCollisionResponder()
	    {
	    }

        public void HandleCollision(IPlayer mario, IEnvironmentObject environmentObject, Side side)
        {

            Rectangle marioRectangle = mario.DestinationRectangle;
            Rectangle envObjRectangle = environmentObject.DestinationRectangle;
            Rectangle intersect = Rectangle.Intersect(marioRectangle, envObjRectangle);

            int height = mario.DestinationRectangle.Height;
            int width = mario.DestinationRectangle.Width;

            switch (side)
            {
                case (Side.Right):
                    {
                        mario.DestinationRectangle = new Rectangle(marioRectangle.X + intersect.Width, marioRectangle.Y, width, height);
                        break;
                    }
                case (Side.Left):
                    {
                        mario.DestinationRectangle = new Rectangle(marioRectangle.X - intersect.Width, marioRectangle.Y, width, height);
                        break;
                    }
                case (Side.Top):
                    {
                        mario.DestinationRectangle = new Rectangle(marioRectangle.X, marioRectangle.Y - intersect.Height, width, height);
                        mario.JumpEnable = true;
                        mario.HitEnemyLast = false;
                        break;
                    }
                case (Side.Bottom):
                    {
                        mario.DestinationRectangle = new Rectangle(marioRectangle.X, marioRectangle.Y + intersect.Height, width, height);
                        mario.NormalForce();
                        break;
                    }
                case (Side.TopLeft):
                    {
                        mario.DestinationRectangle = new Rectangle(marioRectangle.X - intersect.Width, marioRectangle.Y - intersect.Height, width, height);
                        break;
                    }
                case (Side.TopRight):
                    {
                        mario.DestinationRectangle = new Rectangle(marioRectangle.X + intersect.Width, marioRectangle.Y - intersect.Height, width, height);
                        break;
                    }
                case (Side.BottomLeft):
                    {
                        mario.DestinationRectangle = new Rectangle(marioRectangle.X - intersect.Width, marioRectangle.Y + intersect.Height, width, height);
                        break;
                    }
                case (Side.BottomRight):
                    {
                        mario.DestinationRectangle = new Rectangle(marioRectangle.X + intersect.Width, marioRectangle.Y + intersect.Height, width, height);
                        break;
                    }
                case (Side.NotSpecified):
                    {
                        break;
                    }
                default:
                    {
                        break;
                    }
            }

            if (environmentObject is Flag)
            {
                int flagDivider = environmentObject.DestinationRectangle.Height / 5;
                int flagPosition = 0;
                for (int i = 0; i < 4; i++)
                {
                    if ((mario.DestinationRectangle.Y + mario.DestinationRectangle.Height) > 
                        environmentObject.DestinationRectangle.Y + i * flagDivider)
                    {
                        flagPosition = i;
                    }
                }
                MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.FlagScore(mario.DestinationRectangle.X + 30, mario.DestinationRectangle.Y, flagPosition);
                environmentObject.Activate();
                environmentObject.IgnoreCollision = true;
                MarioGame.Instance.CurrentGameMode.CurrentLevel.EndLevel();
                mario.IsInAnimation = true;
                SoundFactory.Instance.FlagpoleSound();
            }

            if (environmentObject is WarpLPipe && side.Equals(Side.Left)
                && MarioGame.Instance.RightIsBeingPressed)
            {
                Vector2 loc = new Vector2(
                    environmentObject.DestinationRectangle.X,
                    environmentObject.DestinationRectangle.Y
                );
               
                foreach (IWarp warp in MarioGame.Instance.CurrentGameMode.CurrentLevel.Warps)
                {
                    Console.WriteLine("pipe: " + loc);
                    Console.WriteLine("warp: " + warp.Location);
                    if (loc.Equals(warp.Location))
                    {
                        SoundFactory.Instance.PipeSound();
                        warp.Warp(mario);
                        MarioGame.Instance.CurrentGameMode.CurrentLevel.IsUnderground = false;
                        MediaPlayer.Pause();
                        MediaPlayer.Play(SoundFactory.Instance.Music());
                    }
                }
            }

            if (environmentObject is WarpLongPipe && 
                side.Equals(Side.Top) && MarioGame.Instance.DownIsBeingPressed)
            {
                Vector2 loc = new Vector2(
                    environmentObject.DestinationRectangle.X,
                    environmentObject.DestinationRectangle.Y
                );

                foreach (IWarp warp in MarioGame.Instance.CurrentGameMode.CurrentLevel.Warps)
                {
                    if (loc.Equals(warp.Location))
                    {
                        SoundFactory.Instance.PipeSound();
                        warp.Warp(mario);
                        MarioGame.Instance.CurrentGameMode.CurrentLevel.IsUnderground = true;
                        MediaPlayer.Pause();
                        MediaPlayer.Play(SoundFactory.Instance.Under());
                    }
                }
            }
        }
    }
}

