using Microsoft.Xna.Framework;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.EnvironmentObjects;

namespace SuperMarioBrothers.Levels
{
    class EndOfLevelAnimaton
    {
        private const int marioMovementVelocity = 4;
        private const int marioShiftVelocity = 25;
        private int castleCenter;

        private bool sidesSwitched = false;
        private bool shiftedRight = false;

        private IPlayer mario;
        private ILevel level;

        private Rectangle flagDestinationRectangle;
        private Rectangle castleDestinationRectangle;

        public EndOfLevelAnimaton(IPlayer mario, ILevel level)
        {
            this.mario = mario;
            this.level = level;

            foreach (IEnvironmentObject obj in level.EnvironmentObjects)
            {
                if (obj is Flag)
                {
                    flagDestinationRectangle = obj.DestinationRectangle;
                }
                else if (obj is Castle)
                {
                    castleDestinationRectangle = obj.DestinationRectangle;
                    castleCenter = (castleDestinationRectangle.Left + castleDestinationRectangle.Right) / 2;
                }
            }
        }

        public void Animate()
        {
            if (mario.DestinationRectangle.Bottom < flagDestinationRectangle.Bottom)
            {
                if (!shiftedRight)
                {
                    mario.DestinationRectangle = new Rectangle(mario.DestinationRectangle.X + marioShiftVelocity,
                        mario.DestinationRectangle.Y, mario.DestinationRectangle.Width, mario.DestinationRectangle.Height);

                    shiftedRight = true;
                }

                mario.DestinationRectangle = new Rectangle(mario.DestinationRectangle.X, mario.DestinationRectangle.Y + marioMovementVelocity,
                    mario.DestinationRectangle.Width, mario.DestinationRectangle.Height);
            }
            else
            {
                if (!sidesSwitched)
                {
                    int xAxisOffset = mario.DestinationRectangle.X + flagDestinationRectangle.Width;
                    mario.DestinationRectangle = new Rectangle(xAxisOffset, mario.DestinationRectangle.Y, mario.DestinationRectangle.Width, 
                        mario.DestinationRectangle.Height);

                    sidesSwitched = true;
                }
                else
                {
                    int marioCenter = (mario.DestinationRectangle.Left + mario.DestinationRectangle.Right) / 2;

                    if (marioCenter < castleCenter)
                    {
                        mario.RightMovement();
                        mario.DestinationRectangle = new Rectangle(mario.DestinationRectangle.X + marioMovementVelocity,
                            mario.DestinationRectangle.Y, mario.DestinationRectangle.Width, mario.DestinationRectangle.Height);
                    }
                }
            }
        }
    }
}
