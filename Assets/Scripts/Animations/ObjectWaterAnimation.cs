using Assets.Scripts.Untils;
using UnityEngine;

namespace Assets.Scripts.Animations
{
    public class ObjectWaterAnimation : MonoBehaviour
    {
        protected float verticalSpeed = 0.5f;
        protected float horizontalSpeed = 0.5f;
        protected float verticalAmplitude = 0.5f;
        protected float horizontalAmplitude = 0.5f;
        [SerializeField] protected Vector3 initialPosition;

        private void Start()
        {
            initialPosition = transform.localPosition;

            verticalSpeed = RandomSpeed.GetRandomSpeed();
            horizontalSpeed = RandomSpeed.GetRandomSpeed();

            verticalAmplitude = RandomPositioner.GetRandomPos().y;
            horizontalAmplitude = RandomPositioner.GetRandomPos().x;


        }
        private void Update()
        {
            StartAnimation();
        }
        protected void StartAnimation()
        {
            float verticalOffset = Mathf.Sin(Time.time * verticalSpeed) * verticalAmplitude;
            float horizontalOffset = Mathf.Sin(Time.time * horizontalSpeed) * horizontalAmplitude;

            transform.localPosition = initialPosition + new Vector3(horizontalOffset, verticalOffset, 0f);


        }

    }
}