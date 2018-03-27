using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.MarioSprites.FireMario
{

    public class DeadFireMarioSprite
    {
        private Texture2D texture;
        private Rectangle sourceRectangle;

        public DeadFireMarioSprite(Texture2D texture)
        {
            this.texture = texture;
            sourceRectangle = new Rectangle(0, 16, 15, 14);
        }
        public void Update(GameTime gameTime)
        {
            // Does not animate
        }
        public void Draw(SpriteBatch spriteBatch, Vector2 location)
        {
            int x = (int)location.X;
            int y = (int)location.Y;
            Rectangle destinationRectangle = new Rectangle(x, y, 50, 50);
            spriteBatch.Begin();
            spriteBatch.Draw(texture, destinationRectangle, sourceRectangle, Color.White);
            spriteBatch.End();
        }
    }
}
 

