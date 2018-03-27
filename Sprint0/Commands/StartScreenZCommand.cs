using SuperMarioBrothers.Screens;

namespace SuperMarioBrothers.Commands
{
    public class StartScreenZCommand : ICommand
    {
        private IScreenCursor cursor;

        public StartScreenZCommand(IScreenCursor cursor)
        {
            this.cursor = cursor;
        }

        public void Execute()
        {
            cursor.SelectOption();
        }
    }
}
