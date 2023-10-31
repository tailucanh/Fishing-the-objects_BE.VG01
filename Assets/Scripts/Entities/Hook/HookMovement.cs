using Assets.Scripts.Audios;
using Assets.Scripts.UI;
using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Entities
{

    public class HookMovement : MonoBehaviour, IMoveHook, IShowTextUI
    {
        public bool IsMovingDown { get;private set; } = false;
        public bool IsMovingHorizontally { get; set; } = false;
        public bool IsMovingUpAfterAttach { get;  set; } = false;

        public bool IsMovingToNewPosition { get;  set; } = false;
        public bool IsAnimating { get;  set; } = false;

        public bool IsCompleteMove { get; set; } = false;
        public bool IsDestroyItem { get; set; }

        private bool _isShowItem = false;


        private Vector3 initialPosition;
        protected float moveSpeed = 5f;
        protected float dropSpeed = 5f;
        protected float moveUpSpeed = 3f;
        


        public bool IsShowUI()
        {
            return _isShowItem;
        }
        private void Start()
        {
            initialPosition = transform.position;
        }


        public void OnMoveHorizontalMiddle(Vector3 targetPosition, IHookAnimation hookAnimation)
        {
            IsCompleteMove = true;
            Vector3 middlePosition = new Vector3(targetPosition.x, transform.position.y, targetPosition.z);
            transform.position = Vector3.MoveTowards(transform.position, middlePosition, moveSpeed * Time.deltaTime);

            if (transform.position == middlePosition)
            {
                initialPosition = middlePosition;
                StartCoroutine(DropHookAfterDelay(0.5f, hookAnimation));
            }
        }


        public void OnAttachObjectToHook(Transform targetObject, IHookAnimation hookAnimation)
        {
            IsCompleteMove = true;
            if (transform.position == targetObject.position)
            {
                StartCoroutine(PlayAnimationAndAttach(targetObject, hookAnimation));
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, targetObject.position, dropSpeed * Time.deltaTime);
            }
        }



        public void OnMoveUp(Transform targetObject, IHookAnimation hookAnimation)
        {
            IsCompleteMove = true;
            Vector3 delayPosition = new Vector3(transform.position.x, initialPosition.y, transform.position.z);

            if (!IsMovingToNewPosition)
            {
                if (transform.position.y >= delayPosition.y)
                {
                    transform.position = delayPosition;
                    StartCoroutine(DelayMoveHookMiddle());
                }
            }
            else
            {
                Vector3 newPosition = new Vector3(transform.position.x, initialPosition.y + 10f, transform.position.z);
                float distanceToInitialPosition = Vector3.Distance(transform.position, newPosition);
                if (distanceToInitialPosition >= 0.15f)
                {
                    transform.position = Vector3.MoveTowards(transform.position, newPosition, moveUpSpeed * Time.deltaTime);
                }
                else
                {  
                    Destroy(targetObject.gameObject);
                    IsMovingUpAfterAttach = false;
                  
                    if (!IsMovingDown)
                    {
                        StartCoroutine(MoveDownSmoothly());
                    }
                }
            }
        }

        private IEnumerator PlayAnimationAndAttach(Transform targetObject, IHookAnimation hookAnimation)
        {
            IsAnimating = true;
            yield return new WaitForSeconds(0.2f);
            hookAnimation.SetAnimation(StateHook.Close, false);
            yield return new WaitForSeconds(0.2f);
            AttachObjectToHook(targetObject);
            IsMovingUpAfterAttach = true;
            IsAnimating = false;
        }

        protected virtual void AttachObjectToHook(Transform targetObject)
        {
            targetObject.SetParent(transform);
            float yOffset = 1.5f;
            targetObject.localPosition = new Vector3(targetObject.localPosition.x, targetObject.localPosition.y + yOffset, targetObject.localPosition.z);
       
        }

        private IEnumerator DelayMoveHookMiddle()
        {
            _isShowItem = true;
            yield return new WaitForSeconds(2f);
            _isShowItem = false;
            IsMovingToNewPosition = true;
        }

        private IEnumerator MoveDownSmoothly()
        {
            IsMovingDown = true;
            IsDestroyItem = true;
            IsCompleteMove = false;
            float startTime = Time.time;

            while (Time.time - startTime < 3f)
            {
                float t = (Time.time - startTime) / 3f;
                transform.position = Vector3.Lerp(transform.position, initialPosition, t);
                yield return null;
            }
            IsMovingToNewPosition = false;
            IsMovingDown = false;
            
        }

        private IEnumerator DropHookAfterDelay(float delay, IHookAnimation hookAnimation)
        {
            hookAnimation.SetAnimation(StateHook.Open, false);
            yield return new WaitForSeconds(delay);
            IsMovingHorizontally = false;
        }
    }
}
