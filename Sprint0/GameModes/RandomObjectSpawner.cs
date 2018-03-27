using Microsoft.Xna.Framework;
using SuperMarioBrothers.Entities.Enemies;
using SuperMarioBrothers.Items;
using SuperMarioBrothers.Levels;
using System;

namespace SuperMarioBrothers.GameModes
{
    public class RandomObjectSpawner
    {
        private ILevel level;
        bool enemyDirectionChange = false;

        public RandomObjectSpawner(ILevel level)
        {
            this.level = level;
        }

        public void GenerateRandomItems(Vector2 location)
        {
            Random rnd = new Random();
            int randomNum = rnd.Next(9);
            System.Console.WriteLine("Item: " + randomNum);
            IItem item;

            if (randomNum >= 0 && randomNum <= 4)
            {
                item = new BigMushroom(location);
            }
            else if (randomNum >= 5 && randomNum <= 7)
            {
                item = new FireFlower(location);
            }
            else
            {
                item = new OneUpMushroom(location);
            }
            item.IsActivated = true;
            item.IsTransparent = false;
            level.Items.Add(item);
        }
        public void GenerateRandomEnemy(Vector2 location)
        {
            Random rnd = new Random();
            int randomNum = rnd.Next(9);
            System.Console.WriteLine("Enemy: " + randomNum);
            IEnemy enemy;

            if (randomNum >= 0 && randomNum <= 6)
            {
                enemy = new Goomba(location);
            }
            else
            {
                enemy = new GreenKoopa(location);
            }
            enemy.IsActivated = true;

            if (enemyDirectionChange)
            {
                enemy.ChangeMovementDirection();
            }
            level.Enemies.Add(enemy);
            enemyDirectionChange = !enemyDirectionChange;
        }
    }
}
