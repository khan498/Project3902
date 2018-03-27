using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Screens
{
    public interface IScreenOption
    {
        Vector2 Location { get; }

        void Draw(SpriteBatch spriteBatch);

        void Select();
    }
}
