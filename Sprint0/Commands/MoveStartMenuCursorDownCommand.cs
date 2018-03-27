using SuperMarioBrothers.Screens;

namespace SuperMarioBrothers.Commands
{
    public class MoveStartMenuCursorDownCommand : ICommand
    {
        private IScreen screen;

        public MoveStartMenuCursorDownCommand(IScreen screen)
        {
            Initialize(screen);
        }

        public void Execute()
        {
            screen.SelectNextOption();
        }

        private void Initialize(IScreen screen)
        {
            this.screen = screen;
        }
    }
}
