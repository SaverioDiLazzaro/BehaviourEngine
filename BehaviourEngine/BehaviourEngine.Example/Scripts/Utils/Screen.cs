using System;

using OpenTK;

namespace BehaviourEngine.Example
{
    public static class Screen
    {
        public static bool IsOutOfScreen(Vector2 position)
        {
            float width = Graphics.Instance.Window.OrthoWidth;
            float height = Graphics.Instance.Window.OrthoHeight;
            return position.X < 0f || position.X > width || position.Y < 0f || position.Y > height;
        }
    }
}