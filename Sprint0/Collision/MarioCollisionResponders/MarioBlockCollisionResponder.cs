using Microsoft.Xna.Framework;
using System.Collections.Generic;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Blocks;
using SuperMarioBrothers.Collision;
using SuperMarioBrothers.Sounds;

namespace SuperMarioBrothers.Collision.MarioCollisionResponders
{
    public class MarioBlockCollisionResponder
    {
        public MarioBlockCollisionResponder()
        {
        }

        public void HandleCollision(IPlayer mario, IBlock block, Side side, List<IBlock> Blocks)
        {
            Rectangle marioRectangle = mario.DestinationRectangle;
            Rectangle blockRectangle = block.DestinationRectangle;
            Rectangle intersect = Rectangle.Intersect(marioRectangle, blockRectangle);

            int height = mario.DestinationRectangle.Height;
            int width = mario.DestinationRectangle.Width;

            if (!block.IgnoreCollision)
            {
                switch (side)
                {
                    case (Side.Top):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X, marioRectangle.Y - intersect.Height, width, height);
                            mario.JumpEnable = true;
                            mario.NormalForce();
                            mario.HitEnemyLast = false;
                            if (block.IsBumped || block.IgnoreCollision)
                            {
                                mario.TakeDamage();
                            }
                            break;
                        }
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

                    case (Side.Bottom):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X, marioRectangle.Y + intersect.Height, width, height);
                            BlockStateTransition(mario, block, Blocks);
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
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X, marioRectangle.Y + intersect.Height, width, height);                        
                            break;
                        }
                    case (Side.BottomRight):
                        {
                            mario.DestinationRectangle = new Rectangle(marioRectangle.X, marioRectangle.Y + intersect.Height, width, height);
                            break;
                        }
                    case (Side.NotSpecified):
                        {
                            mario.NormalForce();
                            break;
                        }
                    default:
                        {
                            break;
                        }
                }
            }
        }

        private void BlockStateTransition(IPlayer mario, IBlock block, List<IBlock> Blocks)
        {
            Vector2 location = new Vector2(block.DestinationRectangle.X, block.DestinationRectangle.Y);
            if (block is QuestionBlock || block is HiddenBlock || block is SpecialBrickBlock)
            {
                block.Bump();
                SoundFactory.Instance.BumpSound();
            }
            else if (block is BrickBlock)
            {
                if (!mario.IsMarioSmall())
                {
                    block.BreakBlock();
                    SoundFactory.Instance.BreakBrickSound();
                    MarioGame.Instance.CurrentGameMode.GameMetric.GameScore.BlockScore(block.DestinationRectangle.X, block.DestinationRectangle.Y);
                }
                else
                {
                    block.Bump();
                    SoundFactory.Instance.BumpSound();
                }
            }
            else if (block is UsedBlock)
            {
                SoundFactory.Instance.BumpSound();
            }
        }
    }
}


