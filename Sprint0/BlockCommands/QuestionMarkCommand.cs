using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SuperMarioBrothers.Interfaces;
using SuperMarioBrothers.Controllers;
using SuperMarioBrothers.Sprites;

namespace SuperMarioBrothers.BlockCommands
{
    public class QuestionMarkCommand : ICommand
    {
        private MarioGame myGame;

        public QuestionMarkCommand(MarioGame game)
        {
            myGame = game;
        }

        public void Execute()
        {
            myGame.QuestionMark = myGame.SpriteFactory.GetQuestionMarkSprite();
        }
    }
}
