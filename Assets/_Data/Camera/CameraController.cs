using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : BaseMonoBehaviour
{
    private static CameraController instance;
    public static CameraController Instance { get => instance; }


    [SerializeField] private float moveDuration = 1.0f;
    [SerializeField] private float moveDistance = 18f;
    private Vector3 initialPosition;
    private bool isMoving = false;


    protected override void Awake()
    {
        base.Awake();
        if (CameraController.instance != null) Debug.LogError("Only one InventoryManager object exists");
        CameraController.instance = this;
    }

    protected override void Start()
    {
        Application.targetFrameRate = 60;
        initialPosition = transform.localPosition;
        StartMovingDown();
        BackgroundController.Instance.OpenBackgroundStart();
    }

    private void StartMovingDown()
    {
        if (!isMoving)
        {
            isMoving = true;
            StartCoroutine(MoveDown());
        }
    }
    private IEnumerator MoveDown()
    {
        yield return new WaitForSeconds(3.3f);
        Vector3 currentPosition = transform.position;

        Vector3 targetPosition = new Vector3(currentPosition.x, currentPosition.y - moveDistance, currentPosition.z);

        float startTime = Time.time;


        while (Time.time - startTime < moveDuration)
        {
            float t = (Time.time - startTime) / moveDuration;

            transform.position = Vector3.Lerp(currentPosition, targetPosition, t);

            yield return null;
        }
        isMoving = false;

    }

    public virtual void OnMovingUp()
    {
        if (!isMoving)
        {
            isMoving = true;
            BackgroundController.Instance.OpenBackgroundEnd();
            StartCoroutine(MoveUp());
            
        }
    }
    private  IEnumerator MoveUp()
    {
        yield return new WaitForSeconds(0.6f);
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = initialPosition;
        float startTime = Time.time;

        while (Time.time - startTime < moveDuration)
        {
            float t = (Time.time - startTime) / moveDuration;
            transform.position = Vector3.Lerp(currentPosition, targetPosition, t);
            yield return null;
        }
        isMoving = false;
        
    }


    protected override void Update()
    {
        base.Update();
        if (InventoryManager.Instance.ListSize() == 0)
        {
            OnMovingUp();
            ExtendHook.Instance.HideHook();
        }
      
    }

 

}
