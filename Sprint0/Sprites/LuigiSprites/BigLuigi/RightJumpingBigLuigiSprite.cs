﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SuperMarioBrothers.Sprites.LuigiSprites.BigLuigi
{
    class RightJumpingBigLuigiSprite : ISprite
    {
        private SpriteDrawer spriteDrawer;
        private const int millisecondsPerFrame = 0;

        private static Rectangle[] sourceFrames = {
            new Rectangle(359, 52, 16, 32)
        };
        
        public RightJumpingBigLuigiSprite(Texture2D texture)
        {
            spriteDrawer = new SpriteDrawer(texture, sourceFrames, millisecondsPerFrame);
        }

        public void Update(GameTime gameTime)
        {
            //not animated
        }

        public void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color)
        {

            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }
    }
}
