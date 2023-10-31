
using Assets.Scripts.Audios;
using Assets.Scripts.UI;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Audios
{
    public class AudioGuidingLoop : MonoBehaviour, IAudioGuidingLoop
    {
        private float _clickInterval = 10f;
        private float _audioInterval = 5f;
        private Coroutine coroutine;
        private AudioGuiding audioGuiding;

        private void Start()
        {
            audioGuiding = GetComponentInChildren<AudioGuiding>();
        }
        public void StartAudio()
        {
            if (ItemsManager.Instance.ListSize() != 4)
            {
                PlayLoop();
            }
        }
       private void PlayLoop()
        {
            coroutine = StartCoroutine(CoroutineAudioGuidingLoop());
        }
        public void StopAudio()
        {
            StopCoroutine(coroutine);
        }

        private IEnumerator CoroutineAudioGuidingLoop()
        {
            float timer = 0f;

            while (timer < _clickInterval)
            {
                timer += Time.deltaTime;
                yield return null;
            }

            Debug.Log("Không có item nào được click trong " + _clickInterval + " giây.");
            Debug.Log("Phát đề bài");
            audioGuiding.Play();

            while (true)
            {

                yield return new WaitForSeconds(_audioInterval);
                Debug.Log("Phát audio tiếp theo sau " + _audioInterval + " giây.");
                audioGuiding.Play();
            }

        }


    }
}
