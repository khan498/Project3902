using Microsoft.Xna.Framework.Graphics;

namespace SuperMarioBrothers.Screens
{
    public interface IScreenCursor
    {
        IScreenOption CurrentOption { get; }

        void Draw(SpriteBatch spriteBatch);

        void MoveTo(IScreenOption option);

        void SelectOption();
    }
}
