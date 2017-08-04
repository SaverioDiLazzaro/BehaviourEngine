using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using NAudio.Wave;

namespace BehaviourEngine
{
    public class AudioSource : Behaviour, IUpdatable
    {
        private IWavePlayer wavePlayer = new WaveOut();

        private AudioClip audioClip;
        public AudioClip AudioClip
        {
            get { return audioClip; }
            set { audioClip = value; wavePlayer.Init(audioClip.audioFileReader); }
        }
        public bool IsLooping { get; private set; }
        public bool IsPlaying { get { return wavePlayer.PlaybackState == PlaybackState.Playing; } }

        public void Play(bool loop = false)
        {
            Stop();
            Reset();

            IsLooping = loop;
            wavePlayer.Play();
        }

        public void Stop()
        {
            IsLooping = false;
            wavePlayer.Stop();
        }

        public void Reset()
        {
            audioClip.audioFileReader.CurrentTime = TimeSpan.Zero;
        }

        public void Pause()
        {
            wavePlayer.Pause();
        }

        public void Resume()
        {
            wavePlayer.Play();
        }

        void IUpdatable.Update()
        {
            if (IsLooping)
            {
                if (!IsPlaying)
                {
                    Play(IsLooping);
                }
            }
        }

    }
    //public class AudioSource : Behaviour, IUpdatable
    //{
    //    public AudioClip AudioClip;
    //    public bool IsLooping { get; private set; }
    //    public bool IsPlaying { get; private set; }

    //    public void Play(bool loop = false)
    //    {
    //        IsLooping = loop;
    //        AudioPlaybackEngine.Instance.PlaySound(AudioClip);
    //    }

    //    public void Stop()
    //    {

    //    }

    //    void IUpdatable.Update()
    //    {
    //        if (IsLooping)
    //        {
    //            if (!IsPlaying)
    //            {
    //                Play(IsLooping);
    //            }
    //        }
    //    }

    //}
}
