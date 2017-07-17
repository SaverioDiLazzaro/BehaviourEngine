using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenTK;

namespace BehaviourEngine
{
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

        public static Vector2 PerVector2(this Matrix2 m, Vector2 vector2)
        {
            float x = Vector2.Dot(m.Row0, vector2);
            float y = Vector2.Dot(m.Row1, vector2);

            return new Vector2(x, y);
        }
    }
}
