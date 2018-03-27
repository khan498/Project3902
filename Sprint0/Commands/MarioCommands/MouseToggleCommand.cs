using SuperMarioBrothers.Controllers;

namespace SuperMarioBrothers.Commands.MarioCommands
{
    public class MouseToggleCommand : ICommand
    {
        private MouseController mouseController;

        public MouseToggleCommand()
        {
            mouseController = MouseController.Instance;
        }

        public void Execute()
        {
            MouseController.Instance.MouseToggle();
        }
    }
}
