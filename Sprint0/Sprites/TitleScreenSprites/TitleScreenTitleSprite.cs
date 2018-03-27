﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites.TitleScreenSprites
{
    public class TitleScreenTitleSprite : ISprite
    {
        private const int millisecondsPerFrame = 0;
        private static Rectangle[] sourceFrames = {
            new Rectangle(1, 60, 176, 88)
        };
        private SpriteDrawer spriteDrawer;

        public TitleScreenTitleSprite(Texture2D spriteSheet)
        {
            Initialize(spriteSheet);
        }

        public void Update(GameTime gameTime)
        {
            // No-op
        }

        public void Draw(
            SpriteBatch spriteBatch,
            Rectangle destinationRectangle,
            Color color
        )
        {
            spriteDrawer.Draw(spriteBatch, destinationRectangle, color);
        }

        private void Initialize(Texture2D spriteSheet)
        {
            spriteDrawer = new SpriteDrawer(
                spriteSheet, 
                sourceFrames, 
                millisecondsPerFrame
            );
        }
    }
}
