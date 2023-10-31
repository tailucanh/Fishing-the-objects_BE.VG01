using UnityEngine;

namespace Assets.Scripts.Audios
{
    public class AudioGuiding : AudioManager
    {

        private static AudioGuiding instance;
        public static AudioGuiding Instance { get => instance; }


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