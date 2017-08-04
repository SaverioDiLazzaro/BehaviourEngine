using System.Collections.Generic;
using Aiv.Fast2D;

namespace BehaviourEngine
{
    public static class AudioManager
    {
        private static Dictionary<string, AudioClip> clips;
        static AudioManager()
        {
            clips = new Dictionary<string, AudioClip>();
        }

        public static void AddAudioClip(string name, AudioClip clip)
        {
            if (!clips.ContainsKey(name))
            {
                clips.Add(name, clip);
            }
        }

        public static AudioClip GetAudioClip(string name)
        {
            if (clips.ContainsKey(name))
            {
                return clips[name];
            }
            return null;
        }
    }
}
