using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : BaseMonoBehaviour
{
    public float moveSpeed = 2.0f;
    private Vector3 targetPosition;
    private Vector3 minBound;
    private Vector3 maxBound;

    protected override void Start()
    {
        minBound = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, 0));
        maxBound = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, 0));
        SetNewRandomTarget();
    }

    protected override void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            SetNewRandomTarget();
        }

        if (transform.position.x < minBound.x || transform.position.x > maxBound.x)
        {
            transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);

            float newX = Mathf.Clamp(transform.position.x, minBound.x, maxBound.x);
            targetPosition = new Vector3(newX, transform.position.y, transform.position.z);
        }
    }

    private void SetNewRandomTarget()
    {
        float randomX = Random.Range(-4.0f, 4.0f);

        targetPosition = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z);

        if (randomX < 0)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
    }


}
