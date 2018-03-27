using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBrothers.Entities.Mario
{
    interface ISpritePicker
    {
        void Update(MarioStateMachine.MarioStatus status, MarioStateMachine.MarioMovement movement, bool facingRight);
    }
}
