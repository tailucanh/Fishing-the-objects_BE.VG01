using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Entities
{
    public class CloudGenerator : MonoBehaviour, ICloudGenerate
    {
        [Header("Cloud Generator")]
        [SerializeField] protected Vector3 startPos;
        [SerializeField] protected List<Transform> cloudPrefabs;
        [SerializeField] protected Transform endPoint;
        private float _spawnInterval = 1.5f;
        private Coroutine _coroutine;


        private void Awake()
        {
            endPoint = transform.Find("EndPoint");
            this.LoadClouds();
        }

        private void Start()
        {
            startPos = transform.position;
        }


        protected virtual void LoadClouds()
        {
            if (cloudPrefabs.Count > 0) return;

            Transform prefabObj = transform.Find("Prefabs");
            foreach (Transform prefab in prefabObj)
            {
                cloudPrefabs.Add(prefab);
            }
        }


        protected void SpawnCloud(Vector3 startPos)
        {
            int randomIndex = Random.Range(0, cloudPrefabs.Count);
            Transform cloud = Instantiate(cloudPrefabs[randomIndex]);


            float startY = Random.Range(startPos.y - 1.5f, startPos.y + 1.5f);
            cloud.transform.position = new Vector3(startPos.x, startY, startPos.z);


            float scale = Random.Range(1.5f, 2f);
            cloud.transform.localScale = new Vector2(scale, scale);


            float speed = Random.Range(1f, 2f);
            cloud.GetComponent<CloudMovement>().StartFloating(speed, endPoint.transform.position.x);
        }

        public void StartGenerate()
        {
            this.Prewarm();
            _coroutine = StartCoroutine(SpawnCloudsPeriodically());
        }

        public void StopGenerate()
        {
            StopCoroutine(_coroutine);
        }


        protected IEnumerator SpawnCloudsPeriodically()
        {
            while (true)
            {
                SpawnCloud(startPos);
                yield return new WaitForSeconds(_spawnInterval);
            }
        }

        public virtual void Prewarm()
        {
            for (int i = 0; i < 8; i++)
            {
                Vector3 spawnPos = startPos + Vector3.right * (i * 2);
                SpawnCloud(spawnPos);
            }
        }

    }
}