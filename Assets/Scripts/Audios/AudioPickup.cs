using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Audios
{
    public class AudioPickup : AudioManager
    {
        private static AudioPickup instance;
        public static AudioPickup Instance { get => instance; }

        protected void Awake()
        {
            if (instance != null) return;
            instance = this;
        }

        public virtual void Play()
        {
            PlayAudio();
        }
        public virtual void Stop()
        {
            StopAudio();
        }


        public virtual void Pause()
        {
            PauseAudio();
        }

        public virtual void Resume()
        {
            ResumeAudio();
        }

    }
}