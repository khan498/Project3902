using Microsoft.Xna.Framework;
using SuperMarioBrothers.Projectile;
using System.Collections.Generic;
using SuperMarioBrothers.Sounds;

namespace SuperMarioBrothers.Collision.FireBallCollisionResponder
{
    public class FireBallBlockCollisionResponder : ICollisionResponder
    {
        public FireBallBlockCollisionResponder()
        {
        }

        public void HandleCollisions(List<ICollision> collisions)
        {
            if (collisions.Count >= 2)
            {
                /*
                 * Find the ICollision with the largest Overlap property
                 */
                FireBallBlockCollision largestCollision = new FireBallBlockCollision();
                foreach (FireBallBlockCollision collision in collisions)
                {
                    if (collision.OverlapArea > largestCollision.OverlapArea)
                    {
                        largestCollision = collision;
                    }
                }

                HandleCollision(largestCollision);
            }
            else if (collisions.Count > 0)
            {
                HandleCollision((FireBallBlockCollision) collisions[0]);
            }
        }

        private void HandleCollision(FireBallBlockCollision collision)
        {
            FireBall fireBall = collision.FireBall;
            Rectangle overlapRect = collision.OverlapRectangle;
            Vector2 normalForceAndFriction = new Vector2(0, -4);

            switch (collision.Side)
            {
                case (Side.Top):
                    {
                        fireBall.Location = Vector2.Add(
                            fireBall.Location,
                            new Vector2(0, -overlapRect.Height)
                        );

                        fireBall.CanBounce = true;

                        fireBall.Velocity = new Vector2(fireBall.Velocity.X, -fireBall.Velocity.Y);
                        fireBall.Velocity = Vector2.Add(fireBall.Velocity, normalForceAndFriction);

                        // If Y velocity would end up being less than zero, just set to zero
                        if (fireBall.Velocity.Y < 0)
                        {
                            fireBall.Velocity = new Vector2(fireBall.Velocity.X, 0);
                        }
                        break;
                    }

                case (Side.Bottom):
                    {
                        fireBall.Location = Vector2.Add(
                            fireBall.Location,
                            new Vector2(0, overlapRect.Height)
                        );

                        fireBall.CanBounce = false;
                        break;
                    }

                case (Side.Left):
                    {
                        fireBall.Explode();
                       if (!fireBall.IsActive)
                       {
                            SoundFactory.Instance.BumpSound();
                        }
                        break;
                    }

                case (Side.Right):
                    {
                        fireBall.Explode();
                        if (!fireBall.IsActive)
                        {
                            SoundFactory.Instance.BumpSound();
                        }
                        break;
                    }

                case (Side.TopLeft):
                    {
                        fireBall.Location = Vector2.Add(
                            fireBall.Location,
                            new Vector2(0, -overlapRect.Height)
                        );

                        fireBall.Velocity = new Vector2(fireBall.Velocity.X, -fireBall.Velocity.Y);
                        fireBall.Velocity = Vector2.Add(fireBall.Velocity, normalForceAndFriction);

                        if (fireBall.Velocity.Y < 0)
                        {
                            fireBall.Velocity = new Vector2(fireBall.Velocity.X, 0);
                        }
                        break;
                    }

                case (Side.TopRight):
                    {
                        fireBall.Location = Vector2.Add(
                            fireBall.Location,
                            new Vector2(0, -overlapRect.Height)
                        );

                        fireBall.Velocity = new Vector2(fireBall.Velocity.X, -fireBall.Velocity.Y);
                        fireBall.Velocity = Vector2.Add(fireBall.Velocity, normalForceAndFriction);

                        if (fireBall.Velocity.Y < 0)
                        {
                            fireBall.Velocity = new Vector2(fireBall.Velocity.X, 0);
                        }
                        break;
                    }

                case (Side.BottomLeft):
                    {
                        fireBall.Location = Vector2.Add(
                            fireBall.Location,
                            new Vector2(-overlapRect.Width, overlapRect.Height)
                        );

                        fireBall.CanBounce = false;
                        break;
                    }

                case (Side.BottomRight):
                    {
                        fireBall.Location = Vector2.Add(
                            fireBall.Location,
                            new Vector2(overlapRect.Width, overlapRect.Height)
                        );

                        fireBall.CanBounce = false;
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
        }
    }
}
