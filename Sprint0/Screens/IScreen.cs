using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Screens
{
    public interface IScreen
    {
        IScreenCursor Cursor { get; }

        void Update(GameTime gameTime);

        void Draw(SpriteBatch spriteBatch);

        void SelectNextOption();
    }
}
