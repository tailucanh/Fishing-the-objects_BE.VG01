using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseMonoBehaviour
{
    private static PlayerMovement instance;
    public static PlayerMovement Instance { get => instance; }


    [SerializeField] protected Vector3 targetPosition;
    [SerializeField] protected float movementDuration = 2.5f;

    protected override void Awake()
    {
        base.Awake();
        if (PlayerMovement.instance != null) Debug.LogError("Only one InventoryManager object exists");
        PlayerMovement.instance = this;
    }



    protected override void Start()
    {
        this.GetTargetPosition();
        StartCoroutine(MoveCharacter());
    }

    protected virtual void GetTargetPosition()
    {
        this.targetPosition = new Vector3(0f, transform.parent.position.y, transform.parent.position.z);
    }

    public virtual void MoveCharacterRight()
    {
        StartCoroutine(MoveRight());
    }


    protected virtual IEnumerator MoveCharacter()
    {
        float startTime = Time.time;
        Vector3 startPosition = transform.parent.position;

        while (Time.time - startTime < this.movementDuration)
        {
            float t = (Time.time - startTime) / this.movementDuration;

            transform.parent.position = Vector3.Lerp(startPosition, targetPosition, t);

            yield return null;
        }

        transform.parent.position = targetPosition;
    }

    protected virtual IEnumerator MoveRight()
    {
        AudioHurrah.Instance.HurrahAudioStop();
        ExtendBoat.Instance.AnimationStart();
        float startTime = Time.time;
        Vector3 startPosition = transform.parent.position;
        Vector3 endPosition = new Vector3(25f, transform.parent.position.y, transform.parent.position.z); // Điểm cuối bên phải (điều chỉnh giá trị theo ý muốn)

        while (Time.time - startTime < 3.5f)
        {
            float t = (Time.time - startTime) / 3.5f;

            transform.parent.position = Vector3.Lerp(startPosition, endPosition, t);

            yield return null;
        }

        transform.parent.position = endPosition;
    }

}
