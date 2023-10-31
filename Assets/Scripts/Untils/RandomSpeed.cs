using UnityEngine;

namespace Assets.Scripts.Untils
{
    public static class RandomSpeed
    {
        private const float _minSpeedSpawn = 0.5f;
        private const float _maxSpeedSpawn = 1.5f;

        public static float GetRandomSpeed()
        {
            return Random.Range(_minSpeedSpawn, _maxSpeedSpawn);
        }

    }
}
