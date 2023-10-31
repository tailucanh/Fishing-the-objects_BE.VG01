using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Untils
{
    [RequireComponent(typeof(AudioSource))]
    public class PlayAudioWhenDestroyObject : MonoBehaviour
    {
        private AudioSource _audioSource;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
            _audioSource.Stop();
        }

        private void Update()
        {
            //StartCoroutine(Destroy());
        }

        private IEnumerator Destroy()
        {
            _audioSource.Stop();
            yield return new WaitWhile(() => gameObject.IsDestroyed());
            _audioSource.Play();
        }
    }
}
