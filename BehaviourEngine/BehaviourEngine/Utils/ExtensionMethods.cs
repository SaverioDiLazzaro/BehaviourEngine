using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BehaviourEngine
{
    //TODO: insert somewhere
    public static class ExtensionMethods
    {
        public static float RadToDeg(this float fRad)
        {
            return 180f / MathHelper.Pi * fRad;
        }

        public static float DegToRad(this float fDeg)
        {
            return MathHelper.Pi / 180f * fDeg;
        }
    }
}
