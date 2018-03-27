using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarioBrothers.Physics
{
    interface IPhysics
    {
        Vector2 Velocity { get; set; }

        void Gravity();
        void NormalForce();

        void Update(Rectangle destinationRectangle);
    }
}
