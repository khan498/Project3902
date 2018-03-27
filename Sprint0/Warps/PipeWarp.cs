using Microsoft.Xna.Framework;
using SuperMarioBrothers.Camera;
using SuperMarioBrothers.Entities.Mario;

namespace SuperMarioBrothers.Warps
{
    public class PipeWarp : IWarp
    {
        private Vector2 start;
        private Vector2 end;

        public Vector2 Location
        {
            get { return start; }
        }

        public PipeWarp(Vector2 start, Vector2 end)
        {
            Initialize(start, end);
        }

        public void Warp(IPlayer player)
        {
            ICamera camera = MarioGame.Instance.CurrentGameMode.Camera;

            if (player.IsMarioBig() || player.IsMarioFire())
            {
                player.CurrentLocationVector = end - new Vector2(0, 32);
            }
            else
            {
                player.CurrentLocationVector = end;
            }

            camera.TopLeftWorldSpace = new Vector2(
                end.X - (camera.Width / 2),
                MarioGame.Instance.CurrentGameMode.Camera.TopLeftWorldSpace.Y
            );

            player.CanGoInPipe = false;
        }

        private void Initialize(Vector2 start, Vector2 end)
        {
            this.start = start;
            this.end = end;
        }
    }
}
