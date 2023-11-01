using Assets.Scripts.Audios;
using Assets.Scripts.UI;
using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

namespace Assets.Scripts.Entities
{

    public class HookMovement : MonoBehaviour, IMoveHook, IDestroyItemByHook,IShowTextUI
    {
        public bool IsMoving { get; set; } = false;
        public bool IsDestroy { get; set; }

        private Vector3 initialPosition;
        protected float moveSpeed = 5f;
        protected float dropSpeed = 5f;
        protected float moveUpSpeed = 3f;

        private bool _isShowItem = false;

        private bool isMovingUpAfterAttach = false;
        private bool isAnimating = false;
        protected bool isMovingDown = false;
        protected bool isMovingToNewPosition = false;

        public bool IsShowUI()
        {
            return _isShowItem;
        }

        public bool DestroyItem()
        {
            return IsDestroy;
        }

        private void Start()
        {
            initialPosition = transform.position;
        }
  
        public void OnMoveHook(Transform targetObject, IHookAnimation hookAnimation)
        {
            if (IsMoving)
            {
                OnMoveHorizontalMiddle(targetObject, hookAnimation);
            }
            else if (!isAnimating)
            {
                OnDropAndAttachObject(targetObject, hookAnimation);
            }
            if (isMovingUpAfterAttach)
            {
               OnMoveUp(targetObject, hookAnimation);

            }

        }


        public void OnMoveHorizontalMiddle(Transform targetObject, IHookAnimation hookAnimation)
        {
            Vector3 middlePosition = new Vector3(targetObject.position.x, transform.position.y, targetObject.position.z);
            transform.position = Vector3.MoveTowards(transform.position, middlePosition, moveSpeed * Time.deltaTime);

            if (transform.position == middlePosition)
            {
                initialPosition = middlePosition;
                StartCoroutine(DropHookAfterDelay(0.5f, hookAnimation));
            }
        }


        public void OnDropAndAttachObject(Transform targetObject, IHookAnimation hookAnimation)
        {
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
            Vector3 delayPosition = new Vector3(transform.position.x, initialPosition.y, transform.position.z);

            if (!isMovingToNewPosition)
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
                    isMovingUpAfterAttach = false;
                  
                    if (!isMovingDown)
                    {
                        StartCoroutine(MoveDownSmoothly());
                    }
                }
            }
        }

        private IEnumerator PlayAnimationAndAttach(Transform targetObject, IHookAnimation hookAnimation)
        {
            isAnimating = true;
            yield return new WaitForSeconds(0.2f);
            hookAnimation.SetAnimation(StateHook.Close, false);
            yield return new WaitForSeconds(0.2f);
            AttachObjectToHook(targetObject);
            isMovingUpAfterAttach = true;
            isAnimating = false;
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
            isMovingToNewPosition = true;
        }

        private IEnumerator MoveDownSmoothly()
        {
            isMovingDown = true;
            IsDestroy = true;
            float startTime = Time.time;

            while (Time.time - startTime < 3f)
            {
                float t = (Time.time - startTime) / 3f;
                transform.position = Vector3.Lerp(transform.position, initialPosition, t);
                yield return null;
            }
            isMovingToNewPosition = false;
            isMovingDown = false;
            
        }

        private IEnumerator DropHookAfterDelay(float delay, IHookAnimation hookAnimation)
        {
            hookAnimation.SetAnimation(StateHook.Open, false);
            yield return new WaitForSeconds(delay);
            IsMoving = false;
        }
       
    }
}
