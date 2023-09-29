using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CloudGenerator : BaseMonoBehaviour
{
    [Header("Cloud Generator")]
    [SerializeField] protected Vector3 startPos;
    [SerializeField] protected List<Transform> cloudPrefabs;
    [SerializeField] protected Transform endPoint;

    protected override void Start()
    {
        base.Start();
        startPos = transform.position;
    }
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadEndPoint();
        this.LoadClouds();
    }
    protected virtual void LoadEndPoint()
    {

        this.endPoint = transform.Find("EndPoint");
    }
    protected override void Update()
    {
        base.Update();
    }
    protected virtual void LoadClouds()
    {
        if (cloudPrefabs.Count > 0) return;
        Transform prefabObj = transform.Find("Prefabs");
        foreach (Transform prefab in prefabObj)
        {
            this.cloudPrefabs.Add(prefab);
        }
    }
    

    protected abstract void SpawnCloud(Vector3 startPos);


}
