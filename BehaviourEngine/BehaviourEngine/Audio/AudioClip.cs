using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NAudio.Wave;

namespace BehaviourEngine
{
    public class AudioClip
    {
        internal AudioFileReader audioFileReader;

        public AudioClip(string fileName)
        {
            audioFileReader = new AudioFileReader(fileName);
        }
    }

    //public class AudioClip
    //{
    //    internal CachedSound sound;
    //    public AudioClip(string fileName)
    //    {
    //        sound = new CachedSound(fileName);
    //    }
    //}
}
