 using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Sprites
{
    public interface ISprite
    {
        void Update(GameTime gameTime);
        void Draw(SpriteBatch spriteBatch, Rectangle destinationRectangle, Color color);
    }
}
