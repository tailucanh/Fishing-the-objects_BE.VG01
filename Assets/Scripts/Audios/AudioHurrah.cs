using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Audios
{
    public class AudioHurrah : AudioManager
    {
        private static AudioHurrah instance;
        public static AudioHurrah Instance { get => instance; }

        protected void Awake()
        {
            if (instance != null) return;
            instance = this;
        }

        public virtual void Play()
        {
            PlayAudio();
            audioSource.loop = true;
        }

        public virtual void Stop()
        {
            StopAudio();
        }

        public virtual void Pasue()
        {
            PauseAudio();
        }

        public virtual void Resume()
        {
            ResumeAudio();
        }




    }
}