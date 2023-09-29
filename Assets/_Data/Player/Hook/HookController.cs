using Spine.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookController : BaseMonoBehaviour
{
    protected static HookController instance;
    public static HookController Instance => instance;
    private Transform targetObject; 
    private Vector3 initialPosition;
    private bool isMovingDown = false;
    private bool isMovingHorizontally;
    private bool shouldMoveUpAfterAttach;
    private float moveSpeed = 5f;  
    private float dropSpeed = 4f;
    private float moveUpSpeed = 2f;
    private float moveUpThreshold = 0.2f;
    private bool isAnimating = false;
    private bool isMovingToNewPosition = false;

    protected override void Awake()
    {
        if (HookController.instance != null) return;
        HookController.instance = this;
    }


    protected override void Start()
    {
        ExtendHook.Instance.HideHook();
        initialPosition = transform.position;
        
    }

    protected override void Update()
    {

        if (targetObject != null)
        {
            
            if (isMovingHorizontally)
            {
               
                ExtendHook.Instance.DisableAnimation();
                Vector3 middlePosition = new Vector3(targetObject.position.x , transform.position.y, targetObject.position.z);
                initialPosition = middlePosition;
                transform.position = Vector3.MoveTowards(transform.position, middlePosition, moveSpeed * Time.deltaTime);
                
                if (transform.position == middlePosition)
                {
                    AudioHook.Instance.HookAudioPlay();
                    StartCoroutine(DropHookAfterDelay(0.5f));
                   
                }
            }
            else
            {
                if (!isAnimating)
                {
                    if (transform.position == targetObject.position)
                    {
                        StartCoroutine(PlayAnimationAndAttach());
                    }
                    else
                    {
                        transform.position = Vector3.MoveTowards(transform.position, targetObject.position, dropSpeed * Time.deltaTime);
                    }
                }

            }
        }
        if (shouldMoveUpAfterAttach)
        {

            Vector3 delayPosition = new Vector3(transform.position.x, initialPosition.y, transform.position.z);

            if (!isMovingToNewPosition)
            {
                if (transform.position.y >= delayPosition.y)
                {
                    Debug.Log("Đến nơi");
                    AudioHook.Instance.HookAudioPasue();
                    transform.position = delayPosition;
                    StartCoroutine(DelayMoveHookMiddle());
                }
               
            }
            else
            {
               
                AudioHook.Instance.HookAudioResume();
                Vector3 newPosition = new Vector3(transform.position.x, initialPosition.y + 10f, transform.position.z);

                float distanceToInitialPosition = Vector3.Distance(transform.position, newPosition);


                if (distanceToInitialPosition >= moveUpThreshold)
                {
                    transform.position = Vector3.MoveTowards(transform.position, newPosition, moveUpSpeed * Time.deltaTime);
                }

                else
                {
                   
                    AudioHook.Instance.HookAudioStop();
                    Destroy(targetObject.gameObject);
                    shouldMoveUpAfterAttach = false;
                    ExtendHook.Instance.EnebalAnimation();
                    AudioPickup.Instance.PickUpAudio();

                    if (!isMovingDown)
                    {
                        StartCoroutine(MoveDownSmoothly());
                      
                        ExtendHook.Instance.AnimationHookWating();
                    }
                }


            }

        }
    }
    private IEnumerator DelayMoveHookMiddle( )
    {

        yield return new WaitForSeconds(2f);
        isMovingToNewPosition = true;

    }

    private IEnumerator PlayAnimationAndAttach()
    {
        isAnimating = true;
        ExtendHook.Instance.AnimationHookOpen();

        yield return new WaitForSeconds(0.2f);
        ExtendHook.Instance.AnimationHookClose();
        yield return new WaitForSeconds(0.2f);
        AttachObjectToHook();
        shouldMoveUpAfterAttach = true;

        isAnimating = false;
    }


    private IEnumerator MoveDownSmoothly()
    {
        isMovingDown = true;

        float startTime = Time.time;
        Vector3 currentPosition = transform.position;

        while (Time.time - startTime < 1f)
        {
            float t = (Time.time - startTime) / 1f;
            transform.position = Vector3.Lerp(currentPosition, initialPosition, t);

            yield return null;
        }

        transform.position = initialPosition;
        isMovingToNewPosition = false;
        isMovingDown = false;
    }

    public void MoveHook(Transform target)
    {
        if (target != null)
        {
            targetObject = target;
            isMovingHorizontally = true;
            shouldMoveUpAfterAttach = false;

        }
    }

    public void AttachObjectToHook()
    {

        targetObject.SetParent(transform);
        float yOffset = 1.5f;
        targetObject.localPosition = new Vector3(targetObject.localPosition.x, targetObject.localPosition.y + yOffset, targetObject.localPosition.z);

    }


    private IEnumerator DropHookAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isMovingHorizontally = false;
    }


}
