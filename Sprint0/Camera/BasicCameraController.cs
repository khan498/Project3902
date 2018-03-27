using Microsoft.Xna.Framework;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Entities.Mario;
using SuperMarioBrothers.Items;
using SuperMarioBrothers.Projectile;
using System.Collections.Generic;

namespace SuperMarioBrothers.Camera
{
    class BasicCameraController : ICameraController
    {
        private ICamera camera;
        private List<IPlayer> players;

        private bool playerHasCentered;

        private Vector2 playerPreviousLocation;
        private Vector2 playerCurrentLocation;

        public BasicCameraController(ICamera camera, List<IPlayer> players)
        {
            this.camera = camera;
            this.players = players;
            playerHasCentered = false;

            playerPreviousLocation = players[0].CurrentLocationVector;
        }

        public void Update()
        {
            playerCurrentLocation = players[0].CurrentLocationVector;

            MoveCameraIfNecessary();
            ActivateEnemies();
            camera.Update();

            playerPreviousLocation = playerCurrentLocation;
            RemoveOutOfBoundObjects();
        }

        private void MoveCamera()
        {
            if (PlayerMoved(playerPreviousLocation, playerCurrentLocation))
            {
                if (PlayerIsAtLeftBoundary(players[0], camera) && !players[0].IsFacingRight())
                {
                    camera.ScrollLeft((int)players[0].VelocityVector.X);
                }
                else if (PlayerIsAtRightBoundary(players[0], camera) && players[0].IsFacingRight())
                {
                    camera.ScrollRight((int)players[0].VelocityVector.X);
                }
            }
        }

        private void MoveCameraIfNecessary()
        {
            if (playerHasCentered)
            {
                MoveCamera();
            }
            else
            {
                CheckIfPlayerPassedCenterOfCamera();
            }
        }

        private void CheckIfPlayerPassedCenterOfCamera()
        {
            if (players[0].CurrentLocationVector.X >= camera.Center.X)
            {
                playerHasCentered = true;
            }
        }

        private void ActivateEnemies()
        {
            foreach (IEnemy enemy in MarioGame.Instance.CurrentGameMode.CurrentLevel.Enemies)
            {
                if (enemy.CurrentLocation.X <= camera.TopLeftWorldSpace.X + camera.Width)
                {
                    enemy.IsActivated = true;
                }
            }
        }

        private static bool PlayerMoved(Vector2 previousLocation, Vector2 currentLocation)
        {
            bool playerMoved = false;

            if (!previousLocation.Equals(currentLocation))
            {
                playerMoved = true;
            }

            return playerMoved;
        }

        private static bool PlayerIsAtLeftBoundary(IPlayer player, ICamera camera)
        {
            bool isAtLeftBoundary = false;

            if(player.CurrentLocationVector.X <= camera.LeftBoundaryX)
            {
                isAtLeftBoundary = true;
            }

            return isAtLeftBoundary;
        }

        private static bool PlayerIsAtRightBoundary(IPlayer player, ICamera camera)
        {
            bool isAtRightBoundary = false;

            if (player.CurrentLocationVector.X >= camera.RightBoundaryX)
            {
                isAtRightBoundary = true;
            }

            return isAtRightBoundary;
        }

        private void RemoveOutOfBoundObjects()
        {
            foreach (IProjectile projectile in MarioGame.Instance.CurrentGameMode.CurrentLevel.Projectiles)
            {
                if (projectile.Location.X >= camera.TopLeftWorldSpace.X + camera.Width ||
                    projectile.Location.X <= camera.TopLeftWorldSpace.X ||
                    projectile.Location.Y >= camera.TopLeftWorldSpace.Y + camera.Height)
                {
                    projectile.IsActive = false;
                }
            }

            foreach (IItem item in MarioGame.Instance.CurrentGameMode.CurrentLevel.Items.ToArray())
            {
                if (item.IsActivated && item.DestinationRectangle.Top >= camera.TopLeftWorldSpace.Y + camera.Height)
                {
                    MarioGame.Instance.CurrentGameMode.CurrentLevel.Items.Remove(item);
                }
            }

            foreach (IEnemy enemy in MarioGame.Instance.CurrentGameMode.CurrentLevel.Enemies.ToArray())
            {
                if (enemy.IsActivated && enemy.DestinationRectangle.Top >= camera.TopLeftWorldSpace.Y + camera.Height)
                {
                    MarioGame.Instance.CurrentGameMode.CurrentLevel.Enemies.Remove(enemy);
                }
            }

            foreach (var player in players)
            {
                if (player.DestinationRectangle.Bottom >= camera.TopLeftWorldSpace.Y + camera.Height)
                {
                    player.BeDead();
                }
            }
        }
    }
}
