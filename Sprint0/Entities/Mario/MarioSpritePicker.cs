using SuperMarioBrothers.Sprites;
using SuperMarioBrothers.Commands.MarioCommands;

namespace SuperMarioBrothers.Entities.Mario
{
    class MarioSpritePicker : ISpritePicker
    {
        IPlayer mario;

        public MarioSpritePicker(IPlayer mario)
        {
            this.mario = mario;
        }
        
        public void Update(MarioStateMachine.MarioStatus status, MarioStateMachine.MarioMovement movement, bool facingRight)
        {
                
                switch (status)
                {
                    case MarioStateMachine.MarioStatus.Dead:
                        mario.CurrentSprite = SpriteFactory.Instance.GetDeadMarioSprite();
                        mario.Dead();

                    break;
                    case MarioStateMachine.MarioStatus.Small:
                        switch (movement)
                        {
                            case MarioStateMachine.MarioMovement.Idle:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightIdleSmallMarioSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftIdleSmallMarioSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Running:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightRunningSmallMarioSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftRunningSmallMarioSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Jumping:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightJumpingSmallMarioSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftJumpingSmallMarioSprite();
                                }
                                break;
                        }
                        break;
                    case MarioStateMachine.MarioStatus.Big:
                        switch (movement)
                        {
                            case MarioStateMachine.MarioMovement.Idle:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightIdleBigMarioSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftIdleBigMarioSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Running:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightRunningBigMarioSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftRunningBigMarioSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Jumping:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightJumpingBigMarioSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftJumpingBigMarioSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Crouching:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightCrouchingBigMarioSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftCrouchingBigMarioSprite();
                                }
                                break;
                        }
                        break;
                    case MarioStateMachine.MarioStatus.Fire:
                        switch (movement)
                        {
                            case MarioStateMachine.MarioMovement.Idle:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightIdleFireMarioSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftIdleFireMarioSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Running:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightRunningFireMarioSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftRunningFireMarioSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Jumping:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightJumpingFireMarioSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftJumpingFireMarioSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Crouching:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightCrouchingFireMarioSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftCrouchingFireMarioSprite();
                                }
                                break;
                        }
                        break;
            }
        }
    }
}
