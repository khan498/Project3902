using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.HUD
{
    public interface IHud
    {
        void Draw(SpriteBatch spriteBatch);

        void DrawIntermediateScreen(SpriteBatch spriteBatch);

        void DrawGameOverScreen(SpriteBatch spriteBatch);

        void Update(GameTime gameTime);
    }
}
