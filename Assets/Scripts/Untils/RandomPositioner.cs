using UnityEngine;

namespace Assets.Scripts.Untils
{
    public static class RandomPositioner
    {
        private const float _bottomLimitSpawn = 0.5f;
        private const float _topLimitSpawn = 1f;
        private const float _leftLimitSpawn = 0.5f;
        private const float _rightLimitSpawn = 1.5f;

        public static Vector3 GetRandomPos()
        {
            float xRandomPos = Random.Range(_leftLimitSpawn, _rightLimitSpawn);
            float yRandomPos = Random.Range(_bottomLimitSpawn, _topLimitSpawn);
            return new Vector3(xRandomPos, yRandomPos,0f);
        }

    }
}
