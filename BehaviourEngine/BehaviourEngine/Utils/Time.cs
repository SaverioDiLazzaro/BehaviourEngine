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

        public static float FixedDeltaTime
        {
            get
            {
                return Physics.Instance.FixedDeltaTime;
            }
        }
    }
}
