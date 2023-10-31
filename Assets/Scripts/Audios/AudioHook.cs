using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Audios
{
    internal class AudioHook : AudioManager
    {

        private static AudioHook instance;
        public static AudioHook Instance { get => instance; }


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
