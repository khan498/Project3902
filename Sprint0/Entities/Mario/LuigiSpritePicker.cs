using SuperMarioBrothers.Sprites;
using SuperMarioBrothers.Commands.MarioCommands;

namespace SuperMarioBrothers.Entities.Mario
{
    class LuigiSpritePicker : ISpritePicker
    {
        IPlayer mario;

        public LuigiSpritePicker(IPlayer mario)
        {
            this.mario = mario;
        }
        
        public void Update(MarioStateMachine.MarioStatus status, MarioStateMachine.MarioMovement movement, bool facingRight)
        {
                
                switch (status)
                {
                    case MarioStateMachine.MarioStatus.Dead:
                        mario.CurrentSprite = SpriteFactory.Instance.GetDeadLuigiSprite();
                        mario.Dead();

                    break;
                    case MarioStateMachine.MarioStatus.Small:
                        switch (movement)
                        {
                            case MarioStateMachine.MarioMovement.Idle:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightIdleSmallLuigiSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftIdleSmallLuigiSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Running:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightRunningSmallLuigiSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftRunningSmallLuigiSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Jumping:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightJumpingSmallLuigiSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftJumpingSmallLuigiSprite();
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
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightIdleBigLuigiSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftIdleBigLuigiSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Running:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightRunningBigLuigiSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftRunningBigLuigiSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Jumping:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightJumpingBigLuigiSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftJumpingBigLuigiSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Crouching:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightCrouchingBigLuigiSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftCrouchingBigLuigiSprite();
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
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightIdleFireLuigiSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftIdleFireLuigiSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Running:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightRunningFireLuigiSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftRunningFireLuigiSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Jumping:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightJumpingFireLuigiSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftJumpingFireLuigiSprite();
                                }
                                break;
                            case MarioStateMachine.MarioMovement.Crouching:
                                if (facingRight)
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetRightCrouchingFireLuigiSprite();
                                }
                                else
                                {
                                    mario.CurrentSprite = SpriteFactory.Instance.GetLeftCrouchingFireLuigiSprite();
                                }
                                break;
                        }
                        break;
            }
        }
    }
}
