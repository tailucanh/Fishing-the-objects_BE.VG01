using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.ScenceController.Cameras
{
    public  class CameraMovement : MonoBehaviour, ICameraMove
    {

        [SerializeField] private float _moveDuration = 1.0f;
        [SerializeField] private float _moveDistance = 18f;
        private Vector3 initialPosition;
        private Vector3 downPosition;


        protected void Start()
        {
            initialPosition = transform.position;
            downPosition = new Vector3(initialPosition.x, initialPosition.y - _moveDistance, initialPosition.z);
        }

        public void OnMoveDown()
        {

            StartCoroutine(CoroutineMove(initialPosition, downPosition, _moveDuration, 0f));
        }


        public void OnMoveUp()
        {
            StartCoroutine(CoroutineMove(transform.position, initialPosition, _moveDuration, 0.5f));

        }

        private IEnumerator CoroutineMove(Vector3 currentPosition, Vector3 targetPosition, float duration, float delayTime)
        {
            yield return new WaitForSeconds(delayTime);

            float startTime = Time.time;

            while (Time.time - startTime < duration)
            {
                float t = (Time.time - startTime) / duration;

                transform.position = Vector3.Lerp(currentPosition, targetPosition, t);

                yield return null;
            }
            transform.position = targetPosition;
        }


    }
}
