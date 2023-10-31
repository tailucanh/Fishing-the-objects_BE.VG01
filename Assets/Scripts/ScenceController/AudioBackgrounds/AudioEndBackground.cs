using UnityEngine;

namespace Assets.Scripts.ScenceController.Audios
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioEndBackground : MonoBehaviour, IAudioBackground
    {

        private AudioSource _audioSource;
        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        public void HandleStateChange(GameState newState)
        {
            switch (newState)
            {
                case GameState.End:
                    PlayAudio();
                    break;
                default:
                    StopAudio();
                    break;
            }
        }



        public void PlayAudio()
        {
            _audioSource.Play();
            
        }

        public void StopAudio()
        {
            _audioSource.Stop();

        }


    }
}
