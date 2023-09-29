using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudsStart : CloudGenerator
{
    protected float spawnInterval = 1.5f;
    protected Coroutine coroutine;


    protected override void Start()
    {
        base.Start();
        this.Prewarm();
        coroutine = StartCoroutine(SpawnCloudsPeriodically());
    }

    protected override void Update()
    {
        base.Update();
        this.StopGenerator();
    }


    protected override void SpawnCloud(Vector3 startPos)
    {

        int randomIndex = Random.Range(0, this.cloudPrefabs.Count);
        Transform cloud = Instantiate(this.cloudPrefabs[randomIndex]);


        float startY = Random.Range(startPos.y - 2.5f, startPos.y + 2.5f);

        cloud.transform.position = new Vector3(startPos.x, startY, startPos.z);

        float speed = Random.Range(1.5f, 2.5f);
        cloud.GetComponent<CloudMovement>().StartFloating(speed, endPoint.transform.position.x);
    }

    protected IEnumerator SpawnCloudsPeriodically()
    {
        while (true)
        {
            SpawnCloud(this.startPos);
            yield return new WaitForSeconds(spawnInterval);
        }
    }


    protected virtual void StopGenerator()
    {
        if (Time.time >= 3.25f)
        {
            StopCoroutine(coroutine);
        }
    }



    protected virtual void Prewarm()
    {
        for (int i = 0; i < 8; i++)
        {
            Vector3 spawnPos = startPos + Vector3.right * (i * 2);
            this.SpawnCloud(spawnPos);
        }
    }
}
