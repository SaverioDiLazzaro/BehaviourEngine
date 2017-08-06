using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Example
{
    [Flags]
    public enum CollisionLayer : uint
    {
        Default = 1,
        Hero    = 2,
        Enemy   = 4,
        Wall    = 8,
        Bullet  = 16
    }
}
