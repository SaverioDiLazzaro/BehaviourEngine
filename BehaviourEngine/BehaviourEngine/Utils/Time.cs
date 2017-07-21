namespace BehaviourEngine
{
    public static class Time
    {
        public static float DeltaTime
        {
            get
            {
                return Graphics.Instance.Window.deltaTime;
            }
        }
    }
}
