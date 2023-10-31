using System.Collections;
using Assets.Scripts.Audios;
using Assets.Scripts.ScenceController.Backgrounds;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class BoatController : MonoBehaviour
    {
        private IAnimationBoat _animationBoat;
        private IMoveBoat _moveBoat;
        private AudioHurrah _audioHurrah;


        private void Awake()
        {
            _animationBoat = GetComponentInChildren<IAnimationBoat>();
            _moveBoat = GetComponent<IMoveBoat>();
            _audioHurrah = GetComponentInChildren<AudioHurrah>();
        }
        protected void Start()
        {
            _audioHurrah.StopAudio();
            _moveBoat.MoveStart();
            BackgroundPlay backgroundPlay = FindObjectOfType<BackgroundPlay>();
            if (backgroundPlay != null)
            {
                backgroundPlay.OnEndWithPlayStatdeChanged += HandlePlayStateChanged;
            }
        }

        private void HandlePlayStateChanged()
        {
            StartCoroutine(PlayDelayEnd());
        }

      
        private IEnumerator PlayDelayEnd()
        {
            _animationBoat.SetAnimation(StateBoat.End, true);
            yield return new WaitForSeconds(3.5f);
            _audioHurrah.Play();
            yield return new WaitForSeconds(2f);
            _audioHurrah.Stop();
            yield return new WaitForSeconds(1f);
            _moveBoat.MoveEnd();
        }

    }
}