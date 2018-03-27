using Microsoft.Xna.Framework;
using SuperMarioBrothers.Sounds;
using Microsoft.Xna.Framework.Media;

namespace SuperMarioBrothers.Entities.Mario
{
    class MarioStateMachine
    {
        public enum MarioStatus { Dead, Small, Big, Fire }
        public enum MarioMovement { Jumping, Idle, Running, Crouching }

        private bool facingRight;
        private MarioStatus status;
        private MarioMovement movement;
        private bool previousFacing;
        private MarioStatus previousStatus;
        private MarioMovement previousMovement;

        private ISpritePicker marioSpritePicker;
        private IPlayer mario;
        private Rectangle smallMarioRectangle;
        private Rectangle bigMarioRectangle;
        private Rectangle crouchingMarioRectangle;
        private int marioWidth = 32;
        private int smallMarioHeight = 36;
        private int bigMarioHeight = 64;
        private int crouchingMarioHeight = 32;


        private bool invincible = false;
        private const int invincibleTime = 800;
        private int currentTime;
        private int damageTime;

        public MarioStatus CurrentState
        {
            get { return status; }
        }

        public MarioMovement CurrentMovement
        {
            get { return movement; }
        }

        public bool FacingRight
        {
            get { return facingRight; }
        }

        public bool IsInvincible
        {
            get { return invincible; }
        }

        public bool IsIdle
        {
            get
            {
                return movement.Equals(MarioMovement.Idle);
            }
        }

        public MarioStateMachine(IPlayer mario, bool isMario)
        {
            this.mario = mario;
            facingRight = true;
            status = MarioStatus.Small;
            movement = MarioMovement.Idle;
            previousFacing = facingRight;
            previousStatus = status;
            previousMovement = movement;
            smallMarioRectangle = new Rectangle(0, 0, marioWidth, smallMarioHeight);
            bigMarioRectangle = new Rectangle(0, 0, marioWidth, bigMarioHeight);
            crouchingMarioRectangle = new Rectangle(0, 0, marioWidth, crouchingMarioHeight);
            if (isMario)
            {
                marioSpritePicker = new MarioSpritePicker(mario);
            }
            else
            {
                marioSpritePicker = new LuigiSpritePicker(mario);
            }

        }

        public void TakeDamage()
        {
            if (!invincible)
            {
                switch (status)
                {
                    case MarioStatus.Fire:
                        BeBig();
                        SoundFactory.Instance.PipeSound();
                        break;
                    case MarioStatus.Big:
                        BeSmall();
                        SoundFactory.Instance.PipeSound();
                        break;
                    case MarioStatus.Small:
                        BeDead();
                        break;
                }
                if (status != MarioStatus.Dead)
                {
                    invincible = true;
                    damageTime = currentTime;
                }
            }
        }

        public void BeDead()
        {
            if (status != MarioStatus.Dead)
            {
                status = MarioStatus.Dead;
                movement = MarioMovement.Idle;
                mario.AddLives(-1);
                MediaPlayer.Stop();
                SoundFactory.Instance.DeadSound();
            }
            smallMarioRectangle.X = mario.DestinationRectangle.X;
            smallMarioRectangle.Y = mario.DestinationRectangle.Y;
            mario.DestinationRectangle = smallMarioRectangle;
        }

        public void BeSmall()
        {
            if (status != MarioStatus.Small)
            {
                status = MarioStatus.Small;
                smallMarioRectangle.X = mario.DestinationRectangle.X;
                smallMarioRectangle.Y = mario.DestinationRectangle.Y;
                if ((previousStatus == MarioStatus.Big) || (previousStatus == MarioStatus.Fire))
                {
                    smallMarioRectangle.Y += (bigMarioHeight - smallMarioHeight);
                }
                mario.DestinationRectangle = smallMarioRectangle;
                if (movement == MarioMovement.Crouching)
                    movement = MarioMovement.Idle;
            }
        }

        public void Crouch()
        {

        }

        public void BeBig()
        {
            if (status != MarioStatus.Big)
            {
                status = MarioStatus.Big;
                bigMarioRectangle.X = mario.DestinationRectangle.X;
                bigMarioRectangle.Y = mario.DestinationRectangle.Y;
                if (previousStatus == MarioStatus.Small)
                {
                    bigMarioRectangle.Y -= (bigMarioHeight - smallMarioHeight);
                }
                mario.DestinationRectangle = bigMarioRectangle;
            }
        }

        public void BeFire()
        {
            if (status != MarioStatus.Fire)
            {
                status = MarioStatus.Fire;
                bigMarioRectangle.X = mario.DestinationRectangle.X;
                bigMarioRectangle.Y = mario.DestinationRectangle.Y;
                if (previousStatus == MarioStatus.Small)
                {
                    bigMarioRectangle.Y -= (bigMarioHeight - smallMarioHeight);
                }
                mario.DestinationRectangle = bigMarioRectangle;
            }

        }

        public void BeIdle()
        {
            if ((status == MarioStatus.Big) || (status == MarioStatus.Fire))
            {
                bigMarioRectangle.X = mario.DestinationRectangle.X;
                bigMarioRectangle.Y = mario.DestinationRectangle.Y;
                if (previousMovement == MarioMovement.Crouching)
                {
                    bigMarioRectangle.Y -= (bigMarioHeight - crouchingMarioHeight);
                }
                mario.DestinationRectangle = bigMarioRectangle;
            }
            movement = MarioMovement.Idle;
        }

        public void UpMovement()
        {
            if (status != MarioStatus.Dead)
            {
                if (previousMovement == MarioMovement.Crouching)
                {
                    bigMarioRectangle.X = mario.DestinationRectangle.X;
                    bigMarioRectangle.Y = mario.DestinationRectangle.Y;
                    if ((previousMovement == MarioMovement.Crouching) && (movement != MarioMovement.Jumping))
                    {
                        bigMarioRectangle.Y += (bigMarioHeight - crouchingMarioHeight);
                    }
                    mario.DestinationRectangle = bigMarioRectangle;
                }

                if ((status == MarioStatus.Big) || (status == MarioStatus.Fire))
                {
                    SoundFactory.Instance.BigJumpSound();
                }else if (status == MarioStatus.Small)
                {
                    SoundFactory.Instance.JumpSound();
                }
                    movement = MarioMovement.Jumping;
            }
        }

        public void DownMovement()
        {
            if ((status == MarioStatus.Big) || (status == MarioStatus.Fire))
            {
                crouchingMarioRectangle.X = mario.DestinationRectangle.X;
                crouchingMarioRectangle.Y = mario.DestinationRectangle.Y;
                
                if ((previousMovement != MarioMovement.Crouching) && (movement != MarioMovement.Crouching))
                {
                    crouchingMarioRectangle.Y += (bigMarioHeight - crouchingMarioHeight);
                }
                
                mario.DestinationRectangle = crouchingMarioRectangle;
                movement = MarioMovement.Crouching;
            }
        }

        public void LeftMovement()
        {
            if (movement != MarioMovement.Crouching)
            {
                if (facingRight)
                {
                    facingRight = false;
                }
                else
                {
                    if ((status == MarioStatus.Big) || (status == MarioStatus.Fire))
                    {
                        bigMarioRectangle.X = mario.DestinationRectangle.X;
                        bigMarioRectangle.Y = mario.DestinationRectangle.Y;
                        mario.DestinationRectangle = bigMarioRectangle;
                    }
                    movement = MarioMovement.Running;
                }
            }
        }

        public void RightMovement()
        {
            if (movement != MarioMovement.Crouching)
            {
                if (!facingRight)
                {
                    facingRight = true;
                }
                else
                {
                    if ((status == MarioStatus.Big) || (status == MarioStatus.Fire))
                    {
                        bigMarioRectangle.X = mario.DestinationRectangle.X;
                        bigMarioRectangle.Y = mario.DestinationRectangle.Y;
                        mario.DestinationRectangle = bigMarioRectangle;
                    }
                    movement = MarioMovement.Running;
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            currentTime += gameTime.ElapsedGameTime.Milliseconds;

            if (invincible && (currentTime - damageTime) > invincibleTime)
            {
                invincible = false;
            }

            if ((status != previousStatus) || (movement != previousMovement) || (previousFacing != facingRight))
            {
                
                marioSpritePicker.Update(status, movement, facingRight);
                previousStatus = status;
                previousMovement = movement;
                previousFacing = facingRight;
            }
        }
    }
}
