using Assets.Scripts.ScenceController;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class BoatMovement : MonoBehaviour,IMoveBoat
    {
        [SerializeField] protected Vector3 targetPosition;
        [SerializeField] protected float movementDuration = 2.5f;
        private IMoveBoneHook _moveBoneHook;


        protected void Start()
        {
            _moveBoneHook = GetComponentInChildren<IMoveBoneHook>();

            targetPosition = new Vector3(0f, transform.position.y, transform.position.z);
        }

        public void MoveStart()
        {
            StartCoroutine(MoveStartAndMoveBoneHook());

        }

        protected IEnumerator MoveStartAndMoveBoneHook()
        {
            yield return StartCoroutine(CoroutineMove(transform.position, targetPosition, movementDuration));

            _moveBoneHook.MoveBone();
        }

        public void MoveEnd()
        {
            Vector3 endPosition = new Vector3(25f, transform.position.y, transform.position.z);
            StartCoroutine(CoroutineMove(transform.position, endPosition, 3.5f));
        }

        protected virtual IEnumerator CoroutineMove(Vector3 currentPosition, Vector3 targetPosition, float duration)
        {
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