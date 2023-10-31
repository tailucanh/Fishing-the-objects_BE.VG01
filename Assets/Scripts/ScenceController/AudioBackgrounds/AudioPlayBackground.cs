using UnityEngine;

namespace Assets.Scripts.ScenceController.Audios
{
    [RequireComponent(typeof(AudioSource))]
    public class AudioPlayBackground : MonoBehaviour, IAudioBackground
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
                case GameState.Play:
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
