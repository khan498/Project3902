using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SuperMarioBrothers.Level_Files;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.Screens
{
    public class StartScreenCursor : IScreenCursor
    {
        private ISprite sprite;
        private Vector2 location;

        private int width = 1;
        private int height = 1;
        private int xOffsetPixels = 2 * DataLibrary.DEFAULT_SIZE;

        private IScreenOption currentOption;

        public IScreenOption CurrentOption
        {
            get
            {
                return currentOption;
            }
        }

        public StartScreenCursor(IScreenOption initialOption)
        {
            Initialize(initialOption);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            sprite.Draw(
                spriteBatch, 
                new Rectangle(
                    (int) location.X, 
                    (int) location.Y, 
                    width * DataLibrary.DEFAULT_SIZE, 
                    height * DataLibrary.DEFAULT_SIZE
                ),
                Color.White
            );
        }

        public void MoveTo(IScreenOption option)
        {
            SetNewOption(option);
        }

        public void SelectOption()
        {
            currentOption.Select();
        }

        private void Initialize(IScreenOption initialOption)
        {
            sprite = SpriteFactory.Instance.GetTitleScreenCursorSprite();
            SetNewOption(initialOption);
        }

        private void SetNewOption(IScreenOption newOption)
        {
            currentOption = newOption;
            location = new Vector2(
                currentOption.Location.X - xOffsetPixels,
                currentOption.Location.Y
            );
        }
    }
}
