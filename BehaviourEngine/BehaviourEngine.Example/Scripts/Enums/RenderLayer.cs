using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BehaviourEngine.Example
{
    //0 => last to render, first visible
    public enum RenderLayer
    {
        Collider,

        Bullet,
        Gun,
        Hero,
        Zombie,
        Platforms,
        Background,
    }
}
